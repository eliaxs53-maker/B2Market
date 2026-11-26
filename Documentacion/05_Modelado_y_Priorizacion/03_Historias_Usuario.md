# Historias de Usuario — B2Market (Libros de Inglés CEC-EPN)

## HU-01: Registro e inicio de sesión de cuenta
* Historia: Como Comprador / Vendedor quiero registrarme en el sistema con correo institucional o personal y poder iniciar sesión una vez activada mi cuenta, para acceder a la plataforma con mi vínculo verificado al CEC-EPN.
* Requerimiento asociado: RF-01 / CU-01 — Registro e inicio de sesión.
* Criterios de aceptación:
  * Escenario 1 (Inicio de sesión con cuenta activada):
    * Given  el usuario registró su cuenta con correo institucional o personal y la bibliotecaria activó la cuenta tras revisar su carné o matrícula del CEC-EPN
    * When el usuario ingresa sus credenciales válidas e inicia sesión
    * Then el sistema permite el acceso a la aplicación.
  * Escenario 2 (Rechazo de cuenta sin activar):
    * Given que el usuario registró una cuenta pero aún no ha sido activada por la bibliotecaria
    * When intenta iniciar sesión
    * Then el sistema rechaza el acceso y muestra un mensaje indicando que la cuenta no está activa.

## HU-02: Publicación de libro en estado Por recibir
* Historia: Como Vendedor, quiero publicar un libro indicando título, autor, nivel, descripción, precio mayor a cero y  una fotografía para ponerlo a disposición del proceso de recepción y venta.
* Requerimiento asociado: RF-02 / CU-02 — Publicación de libro.
* Criterios de aceptación:
  * Escenario 1 (Publicación válida):
    * Given  el vendedor tiene una cuenta activa y completa título, autor, nivel, descripción, precio mayor a cero y al menos una fotografía
    * When confirma la publicación del libro
    * Then el sistema registra el libro en estado "Por recibir".
  * Escenario 2 (Falta fotografía o precio inválido):
    * Given el vendedor omite la fotografía o ingresa un precio menor o igual a cero
    * When intenta publicar el libro
    * Then el sistema rechaza la publicación y no registra el libro.
   
## HU-03: Consulta del catálogo y reserva de libro
* Historia: Como Comprador quiero visualizar los libros recibidos en biblioteca y reservar un libro "Disponible" publicado por otro usuario eligiendo mi método de pago para apartar el ejemplar que necesito.
* Requerimiento asociado: RF-03, RF-04, RD-01 / CU-03 — Reserva de libro.
* Criterios de aceptación:
  * Escenario 1 (Visualización y reserva exitosa):
    * Given  el comprador consulta el catálogo (donde solo aparecen libros recibidos con sus siete datos) y selecciona un libro "Disponible" de otro usuario
    * When confirma la reserva y elige transferencia o efectivo (aplicando 10 % de comisión en efectivo)
    * Then el libro cambia a estado `Pendiente` y queda reservado para ese comprador.
  * Escenario 2 (Ocultamiento de Por recibir y bloqueo de doble reserva):
    * Given  un libro está en estado "Por recibir", ya está en estado "Pendiente" o pertenece al mismo usuario como vendedor
    * When el comprador consulta el catálogo o intenta reservarlo
    * Then el libro `Por recibir` no se muestra en el catálogo y se impide reservar libros propios o ya reservados.

## HU-04: Generación de código de pago por transferencia con vencimiento de 24 horas
* Historia: Como Comprador quiero recibir un código de pago por transferencia con su fecha de vencimiento (o las opciones de reintentar / pagar en efectivo si falla la API) para realizar la transferencia dentro del plazo establecido.
* Requerimiento asociado: RF-05, RD-02 / CU-04 — Generación de código de pago por transferencia.
* Criterios de aceptación:
  * Escenario 1 (Código generado con plazo de 24 horas):
    * Given que el comprador elige transferencia al reservar un libro y la API de pagos responde correctamente,
    * When el sistema solicita el código de pago por el precio del libro
    * Then muestra el código generado con vencimiento 24 horas después de su generación.
  * Escenario 2 (Error en la API de pagos):
    * Given que el comprador elige transferencia y la API de pagos devuelve un error
    * When el sistema procesa la solicitud
    * Then ofrece las opciones de reintentar o pagar en efectivo.
   
## HU-05: Confirmación automática de transferencia y cierre de venta
* Historia: Como Administrador quiero que las confirmaciones válidas de transferencia actualicen el libro a "Vendido" en máximo 30 segundos sin procesar duplicados ni pagos vencidos para mantener la integridad de las ventas.
* Requerimiento asociado: RF-06, RD-02 / CU-05 — Confirmación de transferencia y cierre de venta.
* Criterios de aceptación:
  * Escenario 1 (Confirmación vigente dentro del plazo):
    * Given que existe una reserva vigente por transferencia antes de cumplir 24 horas
    * When el sistema recibe la confirmación de pago desde la API
    * Then actualiza el estado del libro a `Vendido` en máximo 30 segundos.
  * Escenario 2 (Confirmación repetida o fuera de plazo):
    * Given que llega una confirmación duplicada o posterior al vencimiento de 24 horas
    * When el sistema procesa la notificación
    * Then ignora la confirmación repetida y registra como incidencia la confirmación tardía sin generar ventas duplicadas
      
## HU-06: Validación de pago y entrega física del libro
* Historia: Como Bibliotecaria quiero verificar en el sistema que la transferencia esté confirmada o recibir el pago en efectivo con su comisión del 10 % para marcar el libro como `Vendido` y entregarlo físicamente al comprador.
* Requerimiento asociado: RD-01, RF-06 / CU-06 — Validación de pago y entrega de libro.
* Criterios de aceptación:
  * Escenario 1 (Entrega tras transferencia confirmada):
    * Given el comprador se presenta en biblioteca con una reserva cuya transferencia ya consta confirmada en el sistema,
    * When la bibliotecaria verifica el pago y registra la entrega,
    * Then el libro queda en estado `Vendido` y se entrega físicamente al comprador.
  * **Escenario 2 (Cobro en efectivo con comisión del 10 %):**
    * Given el comprador eligió pagar en efectivo para una reserva vigente,
    * When la bibliotecaria recibe el precio del libro más el 10 % de comisión y confirma el cobro en el sistema,
    * Then se registra la comisión correspondiente para la bibliotecaria, el libro pasa a `Vendido` y se entrega al comprador.
