# 01. Requerimientos Refinados - B2Market

Cada ficha usa el mismo identificador del catálogo. La prioridad sigue la técnica MoSCoW (*Must*, *Should*, *Could*).

## Requerimientos funcionales

### RF-01: Registro e inicio de sesión
- **Enunciado:** El sistema deberá permitir registrar una cuenta con correo institucional o personal. El sistema deberá permitir a la bibliotecaria activar la cuenta tras revisar el carné o la matrícula del CEC-EPN. El sistema deberá permitir iniciar sesión únicamente con una cuenta activada.
- **Fuente:** Propietario · **Prioridad:** Must · **Dependencias:** RD-04
- **Criterio de aceptación:** Una cuenta sin activar recibe un mensaje de rechazo al iniciar sesión.

### RF-02: Publicación de libros
- **Enunciado:** El sistema deberá permitir al vendedor publicar un libro con título, autor, nivel, descripción, precio y al menos una fotografía. El sistema deberá rechazar un precio menor o igual a cero. El sistema deberá asignar el estado `Por recibir` al libro publicado.
- **Fuente:** Vendedor · **Prioridad:** Must · **Dependencias:** RF-01, RF-18
- **Criterio de aceptación:** Con datos completos queda `Por recibir`; sin fotografía o con precio cero se rechaza.

### RF-03: Consulta del catálogo
- **Enunciado:** El sistema deberá mostrar en el catálogo únicamente los libros recibidos en la biblioteca. El sistema deberá mostrar de cada libro su título, autor, nivel, descripción, precio, fotografías y estado.
- **Fuente:** Comprador · **Prioridad:** Must · **Dependencias:** RF-01, RF-16
- **Criterio de aceptación:** Un libro `Por recibir` no aparece; un libro recibido muestra los siete datos.

### RF-04: Reserva de libro
- **Enunciado:** El sistema deberá permitir al comprador reservar un libro `Disponible` publicado por otro usuario. El sistema deberá cambiar el libro reservado a `Pendiente`. El sistema deberá impedir una segunda reserva sobre un libro `Pendiente`. El sistema deberá solicitar al comprador el método de pago.
- **Fuente:** Comprador, propietario · **Prioridad:** Must · **Dependencias:** RF-03, RF-11
- **Criterio de aceptación:** Dos intentos sobre un libro producen una sola reserva; el vendedor no puede reservar su libro.

### RF-05: Código de pago por transferencia
- **Enunciado:** Cuando el comprador elija transferencia, el sistema deberá solicitar a la API un código de pago por el precio del libro. El sistema deberá mostrar el código con su fecha de vencimiento. Si la API devuelve un error, el sistema deberá ofrecer reintentar o pagar en efectivo.
- **Fuente:** Propietario, entidad de pagos · **Prioridad:** Must · **Dependencias:** RF-04, API de pagos
- **Criterio de aceptación:** Con respuesta correcta se muestra el código; con error simulado aparecen las dos opciones.

### RF-06: Confirmación de transferencia
- **Enunciado:** El sistema deberá cambiar el libro a `Vendido` en máximo 30 segundos tras recibir la confirmación de pago de una reserva vigente. El sistema deberá ignorar una confirmación repetida. El sistema deberá registrar como incidencia una confirmación recibida después del vencimiento.
- **Fuente:** Administrador, vendedor · **Prioridad:** Must · **Dependencias:** RF-05, RD-02
- **Criterio de aceptación:** Una confirmación simulada cambia el estado a tiempo; la repetida y la tardía no generan ventas.

## Requerimientos no funcionales

### RNF-01: Usabilidad de la reserva
- **Enunciado:** El sistema deberá permitir a un usuario nuevo reservar un libro sin ayuda en máximo 5 clics y 2 minutos desde la pantalla de inicio.
- **Fuente:** Comprador, vendedor · **Prioridad:** Should · **Dependencias:** RF-03, RF-04
- **Criterio de aceptación:** Cinco de cinco usuarios de prueba cumplen ambos límites.

### RNF-02: Protección de datos
- **Enunciado:** El sistema deberá almacenar las contraseñas con hash y sal. El sistema deberá cifrar con TLS 1.2 o superior las conexiones con la base de datos y la API. El sistema deberá cerrar la sesión tras 5 minutos de inactividad. El sistema deberá mostrar los datos de cobro únicamente a su titular y a la bibliotecaria con una transferencia pendiente.
- **Fuente:** Autoridades, entidad de pagos · **Prioridad:** Must · **Dependencias:** Ninguna
- **Criterio de aceptación:** La revisión de base y conexiones y las pruebas de inactividad y permisos cumplen las cuatro condiciones.

### RNF-03: Disponibilidad
- **Enunciado:** El sistema deberá estar disponible al menos el 99 % del horario mensual de atención de la biblioteca.
- **Fuente:** Administrador, autoridades · **Prioridad:** Should · **Dependencias:** RD-03
- **Criterio de aceptación:** El registro de monitoreo de un mes muestra 99 % o más.

## Requerimientos de dominio

### RD-01: Comisión por pago en efectivo
- **Enunciado:** El comprador debe pagar una comisión del 10 % del precio únicamente cuando pague en efectivo. La bibliotecaria debe recibir esa comisión.
- **Fuente:** Propietario · **Prioridad:** Should · **Dependencias:** Ninguna
- **Criterio de aceptación:** Las ventas en efectivo incluyen el 10 %; las ventas por transferencia no lo incluyen.

### RD-02: Plazo de reserva
- **Enunciado:** Una reserva con comprobante debe vencer 24 horas después de la generación del comprobante.
- **Fuente:** Propietario · **Prioridad:** Must · **Dependencias:** Ninguna
- **Criterio de aceptación:** El vencimiento guardado es igual a la hora de generación más 24 horas.


