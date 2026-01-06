// Scroll-based reveal animations using Intersection Observer
// Respects prefers-reduced-motion accessibility setting

const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)').matches;

// Initialize all reveal animations
export function initScrollAnimations() {
    if (prefersReducedMotion) {
        // If user prefers reduced motion, make all elements visible immediately
        document.querySelectorAll('.reveal, .reveal-left, .reveal-right, .reveal-scale, .stagger-children').forEach(el => {
            el.classList.add('visible');
        });
        return;
    }

    const observerOptions = {
        root: null,
        rootMargin: '0px 0px -10% 0px',
        threshold: 0.1
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
                // Optional: unobserve after animation to improve performance
                // observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    // Observe all elements with reveal classes
    document.querySelectorAll('.reveal, .reveal-left, .reveal-right, .reveal-scale, .stagger-children').forEach(el => {
        observer.observe(el);
    });

    return observer;
}

// Re-initialize animations (useful after dynamic content loads)
export function refreshAnimations() {
    initScrollAnimations();
}

// Trigger animation on specific element
export function animateElement(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.add('visible');
    }
}

// Remove animation from element (reset)
export function resetAnimation(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.classList.remove('visible');
    }
}

// Parallax scroll effect for hero elements
export function initParallax() {
    if (prefersReducedMotion) return;

    const parallaxElements = document.querySelectorAll('[data-parallax]');

    if (parallaxElements.length === 0) return;

    window.addEventListener('scroll', () => {
        const scrolled = window.pageYOffset;

        parallaxElements.forEach(el => {
            const speed = parseFloat(el.dataset.parallax) || 0.5;
            const yPos = -(scrolled * speed);
            el.style.transform = `translateY(${yPos}px)`;
        });
    }, { passive: true });
}

// Typing effect for text
export function typeText(elementId, text, speed = 50) {
    const element = document.getElementById(elementId);
    if (!element || prefersReducedMotion) {
        if (element) element.textContent = text;
        return Promise.resolve();
    }

    return new Promise(resolve => {
        element.textContent = '';
        let i = 0;

        const typing = setInterval(() => {
            if (i < text.length) {
                element.textContent += text.charAt(i);
                i++;
            } else {
                clearInterval(typing);
                resolve();
            }
        }, speed);
    });
}
