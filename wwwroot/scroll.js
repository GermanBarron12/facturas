// Función para inicializar el botón de scroll
window.initScrollButton = (dotnetHelper) => {
    let scrollTimeout;

    const handleScroll = () => {
        clearTimeout(scrollTimeout);
        scrollTimeout = setTimeout(() => {
            const scrollPosition = window.scrollY || document.documentElement.scrollTop;
            const shouldShow = scrollPosition > 300; // Mostrar después de 300px de scroll

            dotnetHelper.invokeMethodAsync('UpdateScrollButtonVisibility', shouldShow);
        }, 100); // Debounce de 100ms para mejor rendimiento
    };

    // Remover listener anterior si existe
    window.removeEventListener('scroll', handleScroll);

    // Agregar nuevo listener
    window.addEventListener('scroll', handleScroll);

    // Verificar posición inicial
    handleScroll();
};

// Función para hacer scroll hacia arriba
window.scrollToTop = () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
};