# Modelo de Casos de Uso — Sistema de compra de libros del ingles(cec)
## 1. Identificación de actores
* Cliente : Usuario que necesita un libro de un determinado nivel del ingles del cec (Solo estudiantes pertenecientes a la Escuela Politécnica Nacional)
* Bibliotecaria: Persona que recepta el pago o comprobante de pago y entrega el respectivo producto al usuario
* Vendedor: Registra o publicar libros disponibles para venta
* Administrador: Persona  que gestiona, corrige o modifica registros, catálogos, usuarios y configuraciones del sistema. 
## 2. Listado de casos de uso
* CU-01: Publicación del libro: el vendedor escribe los detalles del libro con su respectiva imagen y el precio
* CU-02: Compra del libro: El usuario busca el libro que quiere , lo selecciona, selecciona su método de pago y recepta el libro
* CU-03: Entrega del libro (transferencia) : La bibliotecaria recepta el pago y luego entrega el libro;
* CU-04: Entrega del libro (efectivo) : La bibliotecaria recepta el pago en efectivo luego realiza la transferencia al código que se le brinda y luego entrega el libro;
* CU-05: Administrar y corregir registros del sistema:** El administrador corrige datos, actualiza catálogos, gestiona usuarios o ajusta registros cuando se requiere modificar información del sistema.
## 3. Escenario detallado: CU-01: Publicación del libro:
* Actor principal: Vendedor.
* Precondiciones:
  * La aplicación se encuentra abierta e inicializada registro/inicio de secion .
  * Se muestran los diferentes libros en venta en el catalogo .
* Flujo principal:
  1. El vendedor ingresa al formulario de publicación de un nuevo libro.
  2. El vendedor completa los datos obligatorios del libro: título, nivel de inglés del CEC al que corresponde, estado/descripción y precio de venta.
  3. El vendedor adjunta una imagen clara del libro.
  4. El vendedor confirma la operación haciendo clic en el botón de publicar/guardar.
  5. El sistema valida que todos los campos obligatorios estén llenos, que el precio sea un valor numérico válido mayor a `0` y que el archivo de imagen cumpla con el formato permitido.
  6. El sistema registra el libro en el catálogo con estado "Disponible" asociado al vendedor.
  7. El sistema muestra un mensaje de confirmación e incorpora el libro en el listado visible para los clientes.
* Flujos alternativos:
  1. FA-01 — Libro sin stock / ya reservado: Si otro estudiante compra el libro antes de confirmar, el sistema notifica que ya no está disponible y actualiza el catálogo.
  2. FA-02 — Comprobante no adjuntado en transferencia: Si elige pago por transferencia y no sube el comprobante, el sistema solicita adjuntar el archivo antes de confirmar.
  3.FA-03 — Cancelar compra:** Si el cliente decide no continuar antes de confirmar la solicitud, el sistema descarta la selección, libera el libro y regresa al catálogo sin generar ningún pedido.
* Postproducciones:
* El libro queda almacenado en el sistema y visible en el catálogo para que los clientes puedan buscarlo y comprarlo.
