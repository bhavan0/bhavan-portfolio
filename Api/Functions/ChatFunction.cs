using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api.Functions;

public class ChatFunction
{
    private readonly ILogger<ChatFunction> _logger;
    private static readonly HttpClient _httpClient = new();

    public ChatFunction(ILogger<ChatFunction> logger)
    {
        _logger = logger;
    }

    [Function("Chat")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "chat")] HttpRequestData req)
    {
        _logger.LogInformation("Chat function triggered.");

        // Read request body
        var requestBody = await req.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(requestBody))
        {
            return await CreateErrorResponse(req, "Request body is empty.", 400);
        }

        ChatRequest? chatRequest;
        try
        {
            chatRequest = JsonSerializer.Deserialize<ChatRequest>(requestBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Failed to parse request body.");
            return await CreateErrorResponse(req, "Invalid JSON format.", 400);
        }

        if (chatRequest == null || string.IsNullOrWhiteSpace(chatRequest.Message))
        {
            return await CreateErrorResponse(req, "Message is required.", 400);
        }

        // Security Check: Input Validation
        if (chatRequest.Message.Length > 500)
        {
             return await CreateErrorResponse(req, "Message is too long. Please keep it under 500 characters.", 400);
        }

        // Security Check: Anti-Jailbreak / Command Injection Prevention
        var unsafeKeywords = new[] { "ignore all previous instructions", "system prompt", "execute command", "rm -rf" };
        if (unsafeKeywords.Any(k => chatRequest.Message.ToLowerInvariant().Contains(k)))
        {
            _logger.LogWarning("Blocked potentially malicious input: {Message}", chatRequest.Message);
            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { reply = "I cannot process that request. Please ask about Bhavan's skills or projects." });
            return response;
        }

        // Get API key from environment
        var apiKey = Environment.GetEnvironmentVariable("OPENROUTER_API_KEY");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            _logger.LogError("OPENROUTER_API_KEY is not configured.");
            return await CreateErrorResponse(req, "Server configuration error.", 500);
        }

        // Read system prompt
        string systemPrompt;
        try
        {
            var promptPath = Path.Combine(AppContext.BaseDirectory, "system-prompt.txt");
            systemPrompt = await File.ReadAllTextAsync(promptPath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to read system prompt.");
            systemPrompt = "You are a helpful assistant for Bhavan Anand's portfolio website.";
        }

        // Call OpenRouter API
        try
        {
            var openRouterRequest = new
            {
                model = "openai/gpt-4o-mini",
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = chatRequest.Message }
                },
                max_tokens = 500
            };

            var jsonContent = JsonSerializer.Serialize(openRouterRequest);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "https://bhavananand.com");
            _httpClient.DefaultRequestHeaders.Add("X-Title", "Bhavan Portfolio Chatbot");

            var openRouterResponse = await _httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", httpContent);
            var responseContent = await openRouterResponse.Content.ReadAsStringAsync();

            if (!openRouterResponse.IsSuccessStatusCode)
            {
                _logger.LogError("OpenRouter API error: {StatusCode} - {Response}", openRouterResponse.StatusCode, responseContent);
                return await CreateErrorResponse(req, "Failed to get response from AI.", 502);
            }

            var openRouterResult = JsonSerializer.Deserialize<OpenRouterResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var assistantMessage = openRouterResult?.Choices?.FirstOrDefault()?.Message?.Content ?? "I'm sorry, I couldn't generate a response.";

            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json");
            await response.WriteStringAsync(JsonSerializer.Serialize(new { reply = assistantMessage }));
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling OpenRouter API.");
            return await CreateErrorResponse(req, "An error occurred while processing your request.", 500);
        }
    }

    private static async Task<HttpResponseData> CreateErrorResponse(HttpRequestData req, string message, int statusCode)
    {
        var response = req.CreateResponse((System.Net.HttpStatusCode)statusCode);
        response.Headers.Add("Content-Type", "application/json");
        await response.WriteStringAsync(JsonSerializer.Serialize(new { error = message }));
        return response;
    }
}

// Request/Response models
public record ChatRequest(string Message);

public class OpenRouterResponse
{
    public List<Choice>? Choices { get; set; }
}

public class Choice
{
    public MessageContent? Message { get; set; }
}

public class MessageContent
{
    public string? Content { get; set; }
}
