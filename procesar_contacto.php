<?php
// Configuración de encabezados
header('Content-Type: application/json');
header('Access-Control-Allow-Origin: *');

// Validar que sea una petición POST
if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
    http_response_code(405);
    echo json_encode(['error' => 'Método no permitido']);
    exit;
}

// Obtener datos del formulario
$nombre = trim($_POST['nombre'] ?? '');
$email = trim($_POST['email'] ?? '');
$mensaje = trim($_POST['mensaje'] ?? '');

// Validaciones
$errores = [];

if (empty($nombre)) {
    $errores[] = 'El nombre es requerido';
}

if (empty($email)) {
    $errores[] = 'El email es requerido';
} elseif (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    $errores[] = 'El email no es válido';
}

if (empty($mensaje)) {
    $errores[] = 'El mensaje es requerido';
} elseif (strlen($mensaje) < 10) {
    $errores[] = 'El mensaje debe tener al menos 10 caracteres';
}

if (!empty($errores)) {
    http_response_code(400);
    echo json_encode(['errores' => $errores]);
    exit;
}

// Configurar correo
$destinatario = 'contacto@nyxtech.com'; // Cambia este email
$asunto = 'Nuevo contacto desde el sitio web - ' . $nombre;

// Construir cuerpo del email
$cuerpo = "
Nombre: {$nombre}
Email: {$email}
Teléfono: " . (trim($_POST['telefono'] ?? '') ?: 'No proporcionado') . "

Mensaje:
{$mensaje}

---
Este mensaje fue enviado desde el formulario de contacto en nyxtech.com
";

// Encabezados del email
$encabezados = "From: {$email}\r\n";
$encabezados .= "Reply-To: {$email}\r\n";
$encabezados .= "X-Mailer: PHP/" . phpversion();
$encabezados .= "Content-Type: text/plain; charset=UTF-8";

// Enviar email
$envio_exitoso = mail($destinatario, $asunto, $cuerpo, $encabezados);

if ($envio_exitoso) {
    // También enviar confirmación al usuario
    $asunto_confirmacion = 'Hemos recibido tu mensaje - NYXTECH';
    $cuerpo_confirmacion = "
Hola {$nombre},

Gracias por contactarnos. Hemos recibido tu mensaje y nos pondremos en contacto contigo pronto.

Tu mensaje:
{$mensaje}

Equipo NYXTECH
www.nyxtech.com
";
    
    mail($email, $asunto_confirmacion, $cuerpo_confirmacion, $encabezados);
    
    http_response_code(200);
    echo json_encode([
        'exitoso' => true,
        'mensaje' => 'Tu mensaje ha sido enviado correctamente. Nos pondremos en contacto pronto.'
    ]);
} else {
    http_response_code(500);
    echo json_encode([
        'error' => 'Error al enviar el mensaje. Intenta nuevamente más tarde.'
    ]);
}
?>
