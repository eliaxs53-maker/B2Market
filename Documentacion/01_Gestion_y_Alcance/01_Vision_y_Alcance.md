# 01. Visión y Alcance - B2Market

# Propósito
Su propósito es reemplazar la venta informal y desorganizada por mensajes, que hoy genera muchas complicaciones para la cordinación entre estudiantes con una aplicación de escritorio donde:
- El vendedor publica su libro con información, fotografías y precio.
- El comprador consulta los libros disponibles y reserva el que le interesa.
- El comprador puederealizar el pago por transferencia o en físico.
- La entrega se hace de forma segura a través de la bibliotecaria, sin que comprador y vendedor tengan que coordinar un encuentro.
  
# Alcance
- **Gestión de cuentas y doble rol:** Registro e inicio de sesión mediante correo institucional o personal (para estudiantes de la EPN y usuarios externos vinculados al CEC), permitiendo que una misma cuenta pueda usar los roles de comprador y vendedor.
- **Publicación y catálogo de libros:** Publicación de los libros con fotos, nivel correspondiente, descripción y precio, además de la consulta de disponibilidad en tiempo real (`Disponible`, `Pendiente`, `Vendido`).
- **Reserva temporal con bloqueo automático:** Al seleccionar *"Quiero comprar"*, el libro pasa a estado `Pendiente` y queda reservado por un plazo máximo de **24 horas** (contadas desde la generación del código o comprobante de pago); si no se concreta el pago en ese tiempo, el sistema lo libera automáticamente a `Disponible`.
- **Gestión de pagos (transferencia y físico):**
  - *Pago por transferencia:* Generación de código de pago mediante la API de DeUna, sin comisión adicional y con confirmación automática del estado a `Vendido`.
  - *Pago en físico:* Generación de comprobante con código del libro y aplicación de una **comisión del 10%** sobre el precio, el cuál será informada previamente al comprador y destinada a la bibliotecaria.
- **Custodia y validación de entrega:** Recepción física de los libros por parte de la bibliotecaria, quien valida el comprobante mediante el código del libro y marca como `Vendido` únicamente las ventas con un pago físico.

# "NO alcance"
El sistema no contara con la capacidad de:
- **Uso remoto o fuera de biblioteca:** La aplicación no estará disponible para ejecución desde dispositivos externos; su uso se restringe exclusivamente a las computadoras de la biblioteca.
- **Otros métodos de pago:** No se aceptarán pagos con tarjetas de crédito/débito ni otros medios digitales.
- **Envíos a domicilio:** No se realizarán entregas fuera de las instalaciones de la biblioteca ni servicios de mensajería.
- **Venta de otros artículos:** No se permitirá publicar materiales ajenos a libros académicos.

# Restricciones
- **Lugar de uso:** La aplicación solo se utiliza en las computadoras de la biblioteca de la universidad.
- **Medios de pago:** Únicamente transferencia (API de DeUna) o pago en físico.
- **Tiempo de reserva:** Un libro con compra iniciada permanece bloqueado 24 horas, contadas desde que se genera el comprobante o el código de pago. Si no se paga, vuelve a estar Disponible y el código generado vence.
- **Comisión:** Solo existe en el pago físico, equivale al 10 % del precio y la recibe la bibliotecaria. El resto del dinero corresponde al vendedor.
- **Dependencia externa:** El pago por transferencia depende de la disponibilidad, las condiciones y los costos de la API de DeUna.
- **Disponibilidad:** El sistema solo estará disponible dentro del horario de atención de la biblioteca.
- **Restricción de roles operativos:** La bibliotecaria cuenta con permisos administrativos limitados y únicamente puede cambiar a `Vendido` aquellos libros cuyo método de pago sea físico

# Definiciones
- **Custodia:** Resguardo físico temporal de un libro publicado en las instalaciones de la biblioteca, bajo responsabilidad de la bibliotecaria desde su recepción hasta su entrega al comprador.
- **Estado `Disponible`:** Libro publicado y en custodia listo para ser reservado y comprado por cualquier usuario.
- **Estado `Pendiente`:** Libro con un proceso de compra iniciado que permanece reservado y bloqueado durante un máximo de 24 horas a la espera de confirmación de pago.
- **Estado `Vendido`:** Libro cuyo pago (por transferencia o en físico) ha sido confirmado y está listo para ser retirado o ya fue entregado mediante su comprobante.
- **Comisión por pago físico:** Cargo adicional equivalente al **10% del precio del libro**, asumido por el comprador al elegir pago en efectivo como compensación por la gestión de cobro de la bibliotecaria.
- **Comprobante con código del libro:** Registro generado por el sistema que contiene el identificador único necesario para que la bibliotecaria verifique la operación y entregue el libro.
- **Usuario:** Persona con cuenta propia que puede publicar y comprar libros.
- **API de pagos (DeUna):** Servicio externo que genera el código de pago y notifica la confirmación de las transferencias.
