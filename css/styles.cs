:root {
  --bg: #0b0f1a;
  --panel: #111a33;
  --accent: #4da3ff;
  --text-muted: #cfd8ff;
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  font-family: system-ui, sans-serif;
}

body {
  /* Fondo base: gradiente oscuro para profundidad */
  background: linear-gradient(120deg, #071023 0%, #071a2b 50%, #0b0f1a 100%);
  color: white;
  background-attachment: fixed;
  position: relative;
  overflow-x: hidden;
}

/* Superposición sutil de luces para mejorar sensación de profundidad */
body::before {
  content: "";
  position: fixed;
  inset: 0;
  background:
    radial-gradient(circle at 10% 10%, rgba(77,163,255,0.04), transparent 15%),
    radial-gradient(circle at 90% 90%, rgba(58,125,212,0.03), transparent 18%);
  pointer-events: none;
  z-index: 0;
  mix-blend-mode: overlay;
}

/* Capa con movimiento muy sutil para dar vida al fondo */
body::after {
  content: "";
  position: fixed;
  inset: 0;
  background: linear-gradient(60deg, rgba(77,163,255,0.02), rgba(58,125,212,0.02));
  animation: gradientShift 18s linear infinite;
  pointer-events: none;
  z-index: 0;
}

@keyframes gradientShift {
  0% {
    transform: translateY(0);
    opacity: 1;
    background-position: 0% 50%;
  }
  50% {
    transform: translateY(2%);
    background-position: 100% 50%;
  }
  100% {
    transform: translateY(0);
    background-position: 0% 50%;
  }
}

/* RESET */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Segoe UI', sans-serif;
}

/* =================================================
   HEADER PRINCIPAL
================================================= */
.header {
  position: fixed;                 /* Mantiene el header fijo */
  top: 0;                           /* Pegado arriba */
  width: 100%;                      /* Ancho completo */
  height: 70px;                     /* Altura del header */
  background: #0c2772; /* Fondo igual al menú móvil */
  backdrop-filter: blur(10px);      /* Efecto vidrio (Apple style) */
  z-index: 9999;                    /* Siempre encima */
  transition: box-shadow 0.3s ease; /* Animación para la sombra */
}
/* Sombra al hacer scroll */
.header.scrolled {
  box-shadow: 0 10px 30px rgba(0,0,0,0.4);
}
/* =================================================
   CONTENEDOR INTERNO
================================================= */
.container-header {
  max-width: 1200px;                /* Limita el ancho */
  height: 100%;
  margin: auto;                     /* Centra el contenedor */
  padding: 0 20px;                  /* Espaciado lateral */
  display: flex;                    /* Flexbox */
  align-items: center;              /* Centra vertical */
  justify-content: space-between;   /* Espacia logo y menú */
}

/* LOGO */
.logo img {
  height: 45px;
}

/* =================================================
   MENÚ DESKTOP
================================================= */

/* NAV SIEMPRE VISIBLE EN DESKTOP */
.nav {
  display: flex;
  position: static;
  background: none;
  padding: 0;
  border-radius: 0;
  box-shadow: none;
}

.nav .menu {
  display: flex;                    /* Menú horizontal */
  gap: 30px;                        /* Espacio entre enlaces */
  list-style: none;                 /* Quita viñetas */
}

.nav .menu a {
  color: #ffffff;
  text-decoration: none;            /* Sin subrayado */
  font-weight: 500;
}

/* =================================================
   BOTÓN HAMBURGUESA
================================================= */
.menu-toggle {
  display: none;                    /* Oculto en escritorio */
  background: none;
  border: none;
  cursor: pointer;
}

/* Líneas del botón ☰ */
.menu-toggle span {
  display: block;
  width: 25px;
  height: 3px;
  background: #ffffff;
  margin: 5px 0;
  transition: all 0.4s ease;
}

/* Animación ☰ → ❌ */
.menu-toggle.active span:nth-child(1) {
  transform: rotate(45deg) translate(5px, 5px);
}

.menu-toggle.active span:nth-child(2) {
  opacity: 0;
}

.menu-toggle.active span:nth-child(3) {
  transform: rotate(-45deg) translate(6px, -6px);
}


/* =================================================
   MENÚ MÓVIL
================================================= */
@media (max-width: 768px) {
  .menu-toggle {
     display: block;
     z-index: 10001;
  }
  .nav {
     display: none;
     position: absolute;
     top: 70px;
     right: 20px;
     background: #0b0f1a;
     width: 220px;
     border-radius: 12px;
     flex-direction: column;
     box-shadow: 0 20px 40px rgba(0,0,0,0.5);
     padding: 15px;
     z-index: 10000;
  }
  .nav.active {
     display: flex;
  }
  .nav .menu {
     flex-direction: column;
     gap: 10px;
  }
  .nav .menu a {
     padding: 15px;
     display: block;
  }
}

/* Espacio para que el contenido no quede debajo del header */
.header-space {
  height: 80px;
}



/* =========== HERO ==========*/
.hero {
  padding: 90px 6%;
  text-align: center;
}

.hero h1 {
  font-size: clamp(2rem, 5vw, 3rem);
}

.hero p {
  max-width: 620px;
  margin: 20px auto;
  color: var(--text-muted);
}

.btn-primary {
  background: var(--accent);
  color: #000;
  padding: 14px 34px;
  border-radius: 30px;
  text-decoration: none;
  font-weight: bold;
}

/* SERVICES */
.services {
  padding: 80px 6%;
  text-align: center;
}

.services-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
  gap: 30px;
  margin-top: 40px;
}

.service-card {
  background: linear-gradient(145deg, #111a33, #0c1228);
  padding: 30px;
  border-radius: 18px;
  border: 1px solid rgba(77,163,255,.25);
}

.service-card i {
  font-size: 2.2rem;
  color: var(--accent);
  margin-bottom: 15px;
}

/* MODEL */
.model {
  padding: 70px 6%;
  background: #0e1629;
  text-align: center;
}

/* CONTACT */
.contact {
  padding: 80px 6%;
  text-align: center;
  background: linear-gradient(135deg, #0b0f1a 0%, #0e1629 100%);
}

.contact h2 {
  font-size: 2.5rem;
  margin-bottom: 50px;
  color: var(--accent);
}

.contact form {
  max-width: 550px;
  margin: auto;
  display: flex;
  flex-direction: column;
  gap: 20px;
  background: rgba(17, 26, 51, 0.6);
  padding: 50px;
  border-radius: 20px;
  border: 1px solid rgba(77, 163, 255, 0.2);
  backdrop-filter: blur(10px);
  box-shadow: 0 8px 32px rgba(0, 0, 0, 0.3);
}

.contact form label {
  display: block;
  text-align: left;
  font-weight: 600;
  margin-bottom: 8px;
  color: #cfd8ff;
  font-size: 14px;
}

.contact input,
.contact textarea {
  padding: 16px 18px;
  border-radius: 12px;
  border: 2px solid rgba(77, 163, 255, 0.2);
  background: rgba(255, 255, 255, 0.05);
  color: white;
  font-size: 15px;
  transition: all 0.3s ease;
  font-family: inherit;
}

.contact input::placeholder,
.contact textarea::placeholder {
  color: rgba(207, 216, 255, 0.5);
}

.contact input:focus,
.contact textarea:focus {
  outline: none;
  border-color: var(--accent);
  background: rgba(255, 255, 255, 0.08);
  box-shadow: 0 0 15px rgba(77, 163, 255, 0.2);
}

.contact textarea {
  resize: vertical;
  min-height: 140px;
}

.contact button {
  padding: 16px 40px;
  border-radius: 12px;
  border: none;
  background: linear-gradient(135deg, var(--accent), #3a7dd4);
  color: #000;
  font-weight: 700;
  font-size: 16px;
  cursor: pointer;
  transition: all 0.3s ease;
  text-transform: uppercase;
  letter-spacing: 1px;
  margin-top: 10px;
}

.contact button:hover {
  transform: translateY(-2px);
  box-shadow: 0 10px 25px rgba(77, 163, 255, 0.4);
}

.contact button:active {
  transform: translateY(0);
}

/* Botón flotante WhatsApp */
.whatsapp-float {
  position: fixed;
  width: 56px;
  height: 56px;
  bottom: 20px;
  right: 20px;
  background-color: #25d366;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 4px 12px rgba(0,0,0,0.3);
  z-index: 9999;
  transition: transform 0.3s ease;
}

.whatsapp-float img {
  width: 32px;
  height: 32px;
}

.whatsapp-float:hover {
  transform: scale(1.1);
}


/* FOOTER */
footer {
  padding: 20px;
  text-align: center;
  background: #0e1629;
}

/* RESPONSIVE */
@media (max-width: 768px) {

  /* Muestra botón hamburguesa */
  .menu-toggle {
    display: block;
  }

  /* Menú oculto por defecto en móvil */
  .nav {
    position: absolute;
    top: 70px;                      /* Debajo del header */
    right: 20px;
    background: #0b0f1a;
    width: 220px;
    border-radius: 12px;
    display: none;                  /* Oculto por defecto */
    box-shadow: 0 20px 40px rgba(0,0,0,0.5);
  }

  /* Menú visible cuando tiene active */
  .nav.active {
    display: flex;
    flex-direction: column;
  }

  /* Menú vertical en móvil */
  .nav .menu {
    flex-direction: column;
  }

  .nav .menu a {
    padding: 15px;
    display: block;
  }
}
