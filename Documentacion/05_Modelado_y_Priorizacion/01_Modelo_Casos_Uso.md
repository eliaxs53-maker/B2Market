# Modelo de Casos de Uso — Sistema de compra de libros del ingles(cec)
## 1. Identificación de actores
* Comprador / Vendedor : Usuario que necesita comprar o vender un libro de un determinado nivel del ingles del cec (Solo estudiantes pertenecientes a la Escuela Politécnica Nacional)
* Bibliotecaria: Persona que recepta el pago o comprobante de pago y entrega el respectivo producto al usuario
* API de Pagos (Actor secundario / sistema externo): Servicio externo encargado de generar códigos de pago por transferencia y enviar las confirmaciones de pago al sistema.
* Administrador: Persona  que gestiona, corrige o modifica registros, catálogos, usuarios y configuraciones del sistema. 
## 2. Listado de casos de uso
* CU-01: Registro e inicio de sesión: El usuario registra una cuenta con correo institucional o personal.
* CU-02: Publicación de libro : El vendedor publica un libro con título, autor, nivel, descripción, precio mayor a cero y al menos una fotografía, quedando registrado en estado "Por recibir".
* CU-03: Reserva de libro : El comprador visualiza los libros y  reserva un libro `Disponible` publicado por otro usuario, cambiándolo a estado `Pendiente` y eligiendo su método de pago (transferencia o efectivo con comisión del 10 %).
* CU-04: Generación de código de pago por transferencia : Al elegir transferencia, el sistema solicita a la API de pagos un código por el valor del libro con vencimiento a 24 horas, o permite reintentar / cambiar a efectivo si la API falla.
* CU-05: Confirmación de transferencia y cierre de venta : El sistema actualiza el libro a `Vendido` en máximo 30 segundos tras recibir la confirmación válida de una reserva vigente, ignorando duplicados y registrando incidencias si llega fuera de plazo.
* CU-06: Validación de pago y entrega de libro : La bibliotecaria verifica en el sistema que la transferencia esté confirmada —o recibe el pago en efectivo incluyendo la comisión del 10 %—, marca el libro como Vendido y lo entrega físicamente al comprador.
## 3. Escenario detallado: CU-01: Publicación del libro:
* Actor principal: Vendedor.
* Requerimiento asociado: RF-02.
* Precondiciones:
  * El vendedor ha registrado su cuenta.
  * El vendedor ha iniciado sesión en B2Market.
* Flujo principal:
  1. El vendedor ingresa al formulario de publicación de un nuevo libro.
  2. El vendedor completa los datos obligatorios del ejemplar: título, autor, nivel de inglés del CEC, descripción y precio de venta.
  3. El vendedor adjunta  una fotografía del libro.
  4. El vendedor confirma la publicación.
  5. El sistema valida que todos los campos estén completos, que el precio sea un valor numérico mayor a `0` y que exista al menos una fotografía válida.
  6. El sistema registra el libro en la base de datos asignándole el estado `Por recibir`.
  7. El sistema muestra un mensaje de confirmación indicando que el libro queda pendiente de recepción física en la biblioteca.
* Flujos alternativos:
  * FA-01 — Precio inválido (menor o igual a cero): Si el vendedor ingresa un precio `<= 0` o no numérico, el sistema rechaza la publicación, muestra un mensaje de validación y solicita corregir el monto.
  * FA-02 — Fotografía faltante o formato inválido: Si el vendedor no adjunta al menos una fotografía o el archivo no cumple con el formato permitido, el sistema detiene el registro e informa el error sin borrar los demás datos ingresados.
  * FA-03 — Campos obligatorios incompletos:Si falta título, autor, nivel o descripción, el sistema indica los campos faltantes y no guarda el registro.
* Postcondiciones:
  * El libro queda almacenado en el sistema con estado `Por recibir`.
  * El libro no aparece visible en el catálogo de compra hasta ser recibido en la biblioteca.
