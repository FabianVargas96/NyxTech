// Espera a que cargue todo el HTML
document.addEventListener('DOMContentLoaded', () => {

  // Botón hamburguesa
  const menuToggle = document.querySelector('.menu-toggle');

  // Menú de navegación
  const nav = document.querySelector('.nav');

  // Header para efecto de sombra
  const header = document.querySelector('.header');

  // ABRIR / CERRAR MENÚ
  menuToggle.addEventListener('click', () => {
    menuToggle.classList.toggle('active'); // Anima ☰ → ❌
    nav.classList.toggle('active');        // Muestra u oculta menú
  });

  // CERRAR MENÚ AL HACER CLICK EN UN LINK
  document.querySelectorAll('.menu a').forEach(link => {
    link.addEventListener('click', () => {
      nav.classList.remove('active');
      menuToggle.classList.remove('active');
    });
  });

  // SOMBRA AL HACER SCROLL
  window.addEventListener('scroll', () => {
    if (window.scrollY > 10) {
      header.classList.add('scrolled');
    } else {
      header.classList.remove('scrolled');
    }
  });

  // FORMULARIO DE CONTACTO
  const contactForm = document.getElementById('contactForm');
  const mensajeRespuesta = document.getElementById('mensajeRespuesta');

  if (contactForm) {
    contactForm.addEventListener('submit', async (e) => {
      e.preventDefault();

      // Obtener datos del formulario
      const formData = new FormData(contactForm);
      const boton = contactForm.querySelector('button');
      const textoOriginal = boton.textContent;

      // Deshabilitar botón y mostrar loading
      boton.disabled = true;
      boton.textContent = 'Enviando...';

      try {
        const response = await fetch('procesar_contacto.php', {
          method: 'POST',
          body: formData
        });

        const datos = await response.json();

        // Mostrar mensaje de respuesta
        mensajeRespuesta.style.display = 'block';

        if (response.ok) {
          mensajeRespuesta.style.background = 'rgba(37, 211, 102, 0.2)';
          mensajeRespuesta.style.borderLeft = '4px solid #25d366';
          mensajeRespuesta.style.color = '#25d366';
          mensajeRespuesta.innerHTML = '✓ ' + datos.mensaje;

          // Limpiar formulario
          contactForm.reset();

          // Ocultar mensaje después de 5 segundos
          setTimeout(() => {
            mensajeRespuesta.style.display = 'none';
          }, 5000);
        } else {
          mensajeRespuesta.style.background = 'rgba(255, 76, 76, 0.2)';
          mensajeRespuesta.style.borderLeft = '4px solid #ff4c4c';
          mensajeRespuesta.style.color = '#ff6b6b';

          if (datos.errores) {
            mensajeRespuesta.innerHTML = '✗ ' + datos.errores.join('<br>✗ ');
          } else {
            mensajeRespuesta.innerHTML = '✗ ' + (datos.error || 'Error al enviar el mensaje');
          }
        }
      } catch (error) {
        mensajeRespuesta.style.display = 'block';
        mensajeRespuesta.style.background = 'rgba(255, 76, 76, 0.2)';
        mensajeRespuesta.style.borderLeft = '4px solid #ff4c4c';
        mensajeRespuesta.style.color = '#ff6b6b';
        mensajeRespuesta.innerHTML = '✗ Error de conexión. Intenta nuevamente.';
      } finally {
        // Restaurar botón
        boton.disabled = false;
        boton.textContent = textoOriginal;
      }
    });
  }

});

