# Especificación de Requerimientos de Software (SRS) — B2Market (Libros de Inglés CEC-EPN)

* Versión: 1.0.0  
* Fecha: 2026-11-26  
Autores: Dylan Haro, Katherine Tipán, Patricio Andy

## 1. Visión, propósito y alcance del sistema
### 1.1 Propósito
Reemplazar la compraventa informal y desorganizada por mensajes entre estudiantes mediante una aplicación de escritorio en la biblioteca del CEC-EPN donde:
* El vendedor publica su libro con información, fotografías y precio.
* El comprador consulta los libros disponibles y reserva el que le interesa.
* El comprador realiza el pago por transferencia o en físico.
* La entrega se realiza de forma segura a través de la bibliotecaria, sin necesidad de coordinar encuentros directos entre comprador y vendedor.

### 1.2 Alcance
* Gestión de cuentas y doble rol:*Registro e inicio de sesión con correo institucional o personal para estudiantes de la EPN y usuarios externos vinculados al CEC, permitiendo que una misma cuenta ejerza los roles de comprador y vendedor previa activación de la bibliotecaria tras revisar el carné o la matrícula.
* Publicación y catálogo de libros: Publicación de libros con título, autor, nivel, descripción, precio (`> 0`) y fotografías, iniciando en estado `Por recibir` hasta su recepción física en biblioteca, y consultando en el catálogo los libros recibidos (`Disponible`, `Pendiente`, `Vendido`).
* Reserva temporal con bloqueo automático: Al seleccionar *"Quiero comprar"* sobre un libro `Disponible` de otro usuario, pasa a `Pendiente` con un plazo máximo de 24 hora contadas desde la generación del código o comprobante de pago (y 15 minutos para elegir método de pago si aún no se genera), liberándose automáticamente a `Disponible` si vence sin pago confirmado.
* Gestión de pagos (transferencia y físico):
  * Transferencia (API de DeUna): Generación de código de pago por el precio del libro con `0 %` de comisión adicional y confirmación automática a `Vendido` en máximo `30 segundos` (o contingencia de reintentar / pasar a físico si falla la API).
  * Pago físico: Generación de comprobante con código del libro y aplicación de una comisión del 10 % sobre el precio, informada previamente al comprador para su aceptación y destinada a la bibliotecaria; el precio íntegro del libro corresponde al vendedor.
* Custodia y validación de entrega: Recepción física de libros por parte de la bibliotecaria, validación mediante comprobante/código e identidad y registro de entrega; la bibliotecaria cuenta con permisos limitados para marcar como `Vendido` únicamente las ventas con pago físico.

### 1.3 Fuera de alcance ("No alcance")
* Uso remoto o fuera de biblioteca: Sin ejecución desde dispositivos externos; restringido a las computadoras de la biblioteca del CEC-EPN.
* Otros métodos de pago: Sin tarjetas de crédito/débito ni otros medios digitales distintos a transferencia (API de DeUna) o pago físico.
* Envíos a domicilio: Sin entregas fuera de la biblioteca ni servicios de mensajería.
* Venta de otros artículos: Sin materiales distintos a libros académicos.

### 1.4 Restricciones y definiciones clave
* Restricciones: Operación exclusiva en computadoras de la biblioteca dentro de su horario de atención; participación limitada a estudiantes EPN/CEC; únicamente transferencia (DeUna) o pago físico; bloqueo de 24 horas desde generación del código/comprobante (y 15 minutos sin método elegido); comisión del `10 %` solo en pago físico para la bibliotecaria; dependencia de disponibilidad, condiciones y costos de la API de DeUna; y permisos operativos limitados de la bibliotecaria.
* Definiciones:
  * Custodia: Resguardo físico temporal de un libro en la biblioteca bajo responsabilidad de la bibliotecaria desde su recepción hasta su entrega.
  * Estados del libro: `Por recibir` (publicado y pendiente de recepción física en biblioteca), `Disponible` (recibido y en custodia, apto para reservar), `Pendiente` (reservado/bloqueado a la espera de confirmación de pago) y `Vendido` (pago confirmado y listo para retiro o ya entregado).
  * Comisión por pago físico: Cargo adicional del `10 %` sobre el precio del libro asumido por el comprador al elegir pago físico y destinado a la bibliotecaria.
  * Comprobante con código del libro: Registro con identificador único para verificar la operación y entregar el libro.
  * API de pagos (DeUna): Servicio externo que genera códigos de pago y notifica confirmaciones de transferencia.
    
## 2. Interesados, adquisición y análisis de requerimientos
### 2.1 Interesados y conflictos resueltos
* Interesados: Comprador (estudiante EPN/CEC), Vendedor (estudiante EPN/CEC), Bibliotecaria, Administrador del sistema (equipo desarrollador), Entidad de pagos (API de DeUna), Autoridades de la universidad/biblioteca y Autoridad tributaria (SRI).
* Conflictos resueltos:
  * CONF-01 (Comprador vs. Bibliotecaria): Comisión del `10 %` solo en pago físico con aviso previo y aceptación explícita; transferencia vía DeUna con `0 %` de comisión.
  * CONF-02 (Comprador vs. Vendedor): Plazo máximo de `24 horas` desde la generación del código/comprobante con liberación automática a `Disponible` si no se paga a tiempo.
  * CONF-03 (Usuarios vs. Autoridades de Biblioteca): Uso exclusivo en computadoras autorizadas dentro de la biblioteca y en su horario oficial.
  * CONF-04 (Comprador vs. Entidad de Pagos / API DeUna): Ante fallos o demoras de la API, se notifica al usuario y se ofrece reintentar o cambiar a pago físico con aviso previo de comisión.

### 2.2 Adquisición, problemáticas y viabilidad de DeUna
* Adquisición: Se aplicaron entrevistas semiestructuradas y observación con la bibliotecaria, encuestas y prototipo con compradores, grupo focal con vendedores, análisis documental de la API de DeUna y revisión normativa con autoridades/propietario, consolidando los registros `101`–`110` y aclarando reglas de comisión (`10 %`), inicio del conteo de `24 horas` y registro separado del monto del vendedor y la comisión de la bibliotecaria.
* Problemáticas y refinamientos (`P-01`–`P-07`): Se corrigieron el ingreso de usuarios externos (activación por bibliotecaria con carné/matrícula), bloqueos sin límite (15 min para elegir método y 24 h desde código/comprobante), ambigüedad de `Por recibir` vs. `Disponible`, comprobante/entrega, y seguridad adaptada a aplicación de escritorio en equipos compartidos.
* Viabilidad de transferencia (`RF-05` y `RF-06`): Se documentó que DeUna implica comisión comercial (`2 %` + IVA), requisitos de afiliación/RUC/cuenta y arquitectura de integración, evaluando las opciones A (cuenta afiliada que cobra y liquida al vendedor), B (transferencia al vendedor sin comisión con revisión manual) y C (simular el pago para el proyecto, definiendo A o B antes de operar con dinero real).

---

## 3. Requerimientos del sistema

### 3.1 Requerimientos funcionales
* RF-01 (Registro e inicio de sesión — *Must*): Registro con correo institucional o personal, activación por la bibliotecaria tras revisar carné o matrícula del CEC-EPN e inicio de sesión únicamente en cuentas activadas. *(Fuente: Propietario · Dep.: RD-04 · Estado: Por validar).*
* RF-02 (Publicación de libros — *Must*): Publicar libro con título, autor, nivel, descripción, precio `> 0` y al menos una fotografía; rechazar precio `<= 0` y asignar estado inicial `Por recibir`. *(Fuente: Vendedor · Dep.: RF-01, RF-18 · Estado: Por validar).*
* RF-03 (Consulta del catálogo — *Must*): Mostrar en el catálogo únicamente libros recibidos en biblioteca con sus siete datos: título, autor, nivel, descripción, precio, fotografías y estado. *(Fuente: Comprador · Dep.: RF-01, RF-16 · Estado: Por validar).*
* RF-04 (Reserva de libro — *Must*): Permitir reservar un libro `Disponible` de otro usuario, cambiarlo a `Pendiente`, impedir segundas reservas sobre `Pendiente` y solicitar método de pago. *(Fuente: Comprador, propietario · Dep.: RF-03, RF-11 · Estado: Refinado).*
* RF-05 (Código de pago por transferencia — *Must*): Al elegir transferencia, solicitar a la API el código por el precio del libro y mostrarlo con fecha de vencimiento; si la API falla, ofrecer reintentar o pagar en efectivo. *(Fuente: Propietario, entidad de pagos · Dep.: RF-04, API de pagos · Estado: Condicionado).*
* RF-06 (Confirmación de transferencia — *Must*): Cambiar el libro a `Vendido` en máximo `30 segundos` tras confirmación válida de reserva vigente, ignorar confirmaciones repetidas y registrar como incidencia las recibidas tras el vencimiento. *(Fuente: Administrador, vendedor · Dep.: RF-05, RD-02 · Estado: Condicionado).*

### 3.2 Requerimientos no funcionales
* RNF-01 (Usabilidad de la reserva — *Should*): Reserva sin ayuda por un usuario nuevo en máximo `5 clics` y `2 minutos` desde la pantalla de inicio (`5/5` usuarios cumplen). *(Fuente: Comprador, vendedor · Dep.: RF-03, RF-04 · Estado: Refinado).*
* RNF-02 (Protección de datos — *Must*): Contraseñas con hash y sal, cifrado TLS `1.2+` en conexiones con base de datos y API, cierre de sesión tras `5 minutos` de inactividad y acceso a datos de cobro restringido al titular y a la bibliotecaria con transferencia pendiente. *(Fuente: Autoridades, entidad de pagos · Dep.: Ninguna · Estado: Por validar).*
* RNF-03 (Disponibilidad — *Should*): Disponibilidad de al menos `99 %` del horario mensual de atención de la biblioteca. *(Fuente: Administrador, autoridades · Dep.: RD-03 · Estado: Refinado).*

### 3.3 Requerimientos de dominio
* RD-01 (Comisión por pago en efectivo — *Should*): Comisión del `10 %` del precio únicamente en pago en efectivo, pagada por el comprador y destinada a la bibliotecaria (`0 %` en transferencia). *(Fuente: Propietario · Dep.: Ninguna · Estado: Analizado).*
* RD-02 (Plazo de reserva — *Must*): Una reserva con comprobante/código vence `24 horas` después de su generación. *(Fuente: Propietario · Dep.: Ninguna · Estado: Analizado).*

---

## 4. Modelo y diagrama de casos de uso

### 4.1 Listado de casos de uso
* CU-01: Registro e inicio de sesión (`RF-01`): El usuario registra una cuenta con correo institucional o personal (activada por la bibliotecaria tras revisar carné o matrícula CEC-EPN para iniciar sesión).
* CU-02: Publicación de libro (`RF-02`): El vendedor publica un libro con título, autor, nivel, descripción, precio mayor a cero y al menos una fotografía, quedando en estado `Por recibir`.
* CU-03: Reserva de libro (`RF-03`, `RF-04`, `RD-01`): El comprador visualiza los libros y reserva un libro `Disponible` publicado por otro usuario, cambiándolo a `Pendiente` y eligiendo método de pago (transferencia o efectivo con comisión del `10 %`).
* CU-04: Generación de código de pago por transferencia (`RF-05`, `RD-02`): Al elegir transferencia, el sistema solicita a la API de pagos un código por el valor del libro con vencimiento a `24 horas`, o permite reintentar / cambiar a efectivo si la API falla.
* CU-05: Confirmación de transferencia y cierre de venta (`RF-06`, `RD-02`): El sistema actualiza el libro a `Vendido` en máximo `30 segundos` tras recibir la confirmación válida de una reserva vigente, ignorando duplicados y registrando incidencias si llega fuera de plazo.
* CU-06: Validación de pago y entrega de libro (`RD-01`, `RF-06`): La bibliotecaria verifica en el sistema que la transferencia esté confirmada —o recibe el pago en efectivo incluyendo la comisión del `10 %`—, marca el libro como `Vendido` y lo entrega físicamente al comprador.

### 4.2 Escenario detallado: CU-02 — Publicación de libro
* Actor principal: Vendedor (`RF-02`).
* Precondiciones: El vendedor ha registrado su cuenta (activada por la bibliotecaria) y ha iniciado sesión en B2Market.
* Flujo principal:
  1. El vendedor ingresa al formulario de publicación de un nuevo libro.
  2. El vendedor completa título, autor, nivel de inglés del CEC, descripción y precio de venta.
  3. El vendedor adjunta una fotografía (al menos una).
  4. El vendedor confirma la publicación.
  5. El sistema valida campos completos, precio numérico mayor a `0` y al menos una fotografía válida.
  6. El sistema registra el libro en la base de datos con estado `Por recibir`.
  7. El sistema muestra confirmación de que el libro queda pendiente de recepción física en la biblioteca.
* Flujos alternativos:
  * FA-01 — Precio inválido (`<= 0` o no numérico): El sistema rechaza la publicación, muestra validación y pide corregir el monto.
  * FA-02 — Fotografía faltante o formato inválido: El sistema detiene el registro, informa el error y conserva los demás datos ingresados.
  * FA-03 — Campos obligatorios incompletos: El sistema indica los campos faltantes y no guarda el registro.
* Postcondiciones: El libro queda almacenado en estado `Por recibir` y no aparece en el catálogo de compra hasta ser recibido en la biblioteca.

