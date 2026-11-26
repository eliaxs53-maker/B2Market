# 02. Informe de Análisis y Refinamiento - B2Market

## 1. Problemáticas detectadas

### P-01: Usuarios externos
- **Evidencia:** RF-01, la Visión y Alcance y la Matriz de Interesados aceptan personas que no son estudiantes del CEC-EPN.
- **Justificación:** el sistema es solo para estudiantes del CEC-EPN y tener un correo no demuestra serlo.
- **Corrección:** la bibliotecaria activa la cuenta después de revisar el carné o la matrícula.

### P-02: Reserva bloqueada sin límite
- **Evidencia:** el libro queda `Pendiente` al pulsar "Quiero comprar", pero las 24 horas empiezan cuando se genera el código.
- **Justificación:** si el comprador no elige cómo pagar, el libro nunca se libera.
- **Corrección:** dar 15 minutos para elegir el método de pago; si no lo hace, vuelve a `Disponible`.

### P-03: Pago con DeUna
- **Evidencia:** planteamos un pago directo al vendedor y sin comisión, pero DeUna cobra 2 % a negocios y pide RUC y cuenta en Banco Pichincha [1].
- **Justificación:** el dinero llega al negocio afiliado y no a cada estudiante que vende.
- **Corrección:** dejar RF-05 y RF-06 condicionados a una de las alternativas de la sección 3.

### P-04: Entrega del dinero en pagos en efectivo
- **Evidencia:** RF-12 dice repartir el dinero de forma "justa", sin explicar cómo lo recibe el vendedor.
- **Justificación:** no se puede comprobar y el vendedor no sabe cuándo se le pagará.
- **Corrección:** la bibliotecaria se queda con la comisión y transfiere el precio del libro al vendedor, quien ya no debe ir a retirarlo.

### P-05: Libro publicado que aún no está en la biblioteca
- **Evidencia:** `Disponible` significa que el libro está en custodia, pero RF-02 lo muestra así apenas se publica.
- **Justificación:** alguien podría pagar un libro que no se ha entregado en la biblioteca.
- **Corrección:** usar el estado `Por recibir` hasta que la bibliotecaria confirme la recepción.

### P-06: Comprobante y entrega poco claros
- **Evidencia:** el README genera el código después del pago y la Visión y Alcance, en efectivo, antes.
- **Justificación:** tampoco se sabe si un libro `Vendido` ya fue retirado.
- **Corrección:** crear un código por cada compra y registrar la entrega.

### P-07: Seguridad pensada para una web
- **Evidencia:** RNF-02 habla de HTTPS entre "navegador y servidor", pero la aplicación es de escritorio.
- **Justificación:** no hay navegador y las computadoras de la biblioteca son compartidas.
- **Corrección:** proteger contraseñas, conexiones, sesiones y datos de cobro.

## 2. Dependencias entre requerimientos

| Requerimiento | Depende de | Motivo |
|---|---|---|
| RF-01 y RF-11 (cuenta y doble rol) | RD-04 | Solo estudiantes verificados compran y venden. |
| RF-18 (datos de cobro) | RF-01, RNF-02 | Son datos de una cuenta y deben protegerse. |
| RF-02 (publicar) | RF-01, RF-18 | Se necesita saber quién vende y dónde pagarle. |
| RF-16 y RF-03 (recepción y catálogo) | RF-02 | El libro se publica, se recibe y luego se muestra. |
| RF-04 (reservar) | RF-03 | Solo se reserva un libro `Disponible`. |
| RF-07 y RF-10 (código y liberación) | RF-04, RD-02 | Ambos parten de una reserva. |
| RF-05 y RF-06 (transferencia) | RF-04, API de pagos | Primero se genera el cobro y después se confirma. |
| RF-08 y RF-12a (comisión y total) | RF-04, RD-01 | Aplican al elegir efectivo. |
| RF-09 y RF-12b (cobro en efectivo) | RF-07, RF-12a | Se necesita el código y el total. |
| RF-12c y RF-19 (transferencia y aviso) | RF-12b, RF-18, RD-05 | Se transfiere y luego se avisa al vendedor. |
| RF-17 (entrega) | RF-06 o RF-09 | Solo se entrega un libro pagado. |

## 3. Viabilidad del pago por transferencia (RF-05 y RF-06)

| Dimensión | Análisis |
|---|---|
| Técnica | Hay API y avisos de pago [1], pero la aplicación necesitaría un servidor intermedio o consultar el estado. |
| Económica | La comisión es 2 % más IVA [2]; en un libro de $20 son $0,40 más IVA. |
| Temporal | Es lo que más puede tardar, porque requiere afiliación, credenciales y pruebas. |
| Organizacional | Alguien con RUC debe afiliarse y el CEC-EPN debe autorizarlo. |

Opciones: **A)** una sola cuenta afiliada cobra y luego paga al vendedor; **B)** el comprador transfiere al vendedor sin comisión [3], con revisión manual; **C)** simular el pago.

**Conclusión:** tal como estaba planteado no es viable. Para el proyecto recomendamos la opción C y decidir entre A o B antes de usarlo con dinero real.

## 4. Requerimientos refinados

| ID | Antes | Después | Problema |
|---|---|---|---|
| RF-01 | Cualquier persona se registra. | Solo estudiantes del CEC-EPN, con cuenta activada por la bibliotecaria. | P-01 |
| RF-02 | Publicar con datos, precio y foto. | Publicar con datos, precio mayor a cero y foto; queda `Por recibir`. | P-05 |
| RF-03 | Ver libros disponibles. | Ver solo libros ya recibidos en la biblioteca. | P-05 |
| RF-04 | Reservar con "Quiero comprar". | Reservar un libro ajeno y `Disponible`, y pedir el método de pago. | P-02 |
| RF-05 | Generar código con la API. | Generar el código; si falla, permitir reintentar o pagar en efectivo. | P-03 |
| RF-06 | Marcar `Vendido` al pagar. | Marcarlo en máximo 30 segundos, sin duplicar ni aceptar pagos vencidos. | P-03 |
| RF-07 | Comprobante con código del libro. | Comprobante con código único de compra, método, total y vencimiento. | P-06 |
| RF-08 | Avisar la comisión. | Mostrar comisión del 10 % y total, y pedir aceptación. | P-04 |
| RF-09 | Bibliotecaria marca `Vendido`. | Hacerlo solo con reserva vigente en efectivo y registrar quién, cuándo y cuánto. | P-06 |
| RF-10 | Liberar a las 24 horas. | Liberar a las 24 horas, o a los 15 minutos sin método; revisar al abrir la aplicación. | P-02 |
| RF-12a y b | Repartir de forma justa. | Sumar el 10 % al precio y registrar la comisión y el valor a pagar al vendedor. | P-04 |
| RF-12c | Nuevo | La bibliotecaria transfiere el precio sin comisión en 1 día hábil y guarda la referencia. | P-04 |
| RF-16 | Nuevo | La bibliotecaria registra la recepción y el libro pasa a `Disponible`. | P-05 |
| RF-17 | Nuevo | La bibliotecaria verifica código e identidad y registra la entrega. | P-06 |
| RF-18 y RF-19 | Nuevo | Guardar los datos de cobro del vendedor y avisarle cuando se le transfiera. | P-04 |
| RNF-02 | Contraseñas con hash y HTTPS. | Hash con sal, conexiones cifradas, cierre a los 5 minutos y datos de cobro restringidos. | P-07 |

**Reglas:** RD-01, comisión del 10 % solo en efectivo (costos de DeUna por definir); RD-02, reserva de 24 horas desde el código; RD-03, uso solo en la biblioteca del CEC-EPN; RD-04, compran y venden solo sus estudiantes; RD-05, el vendedor recibe por transferencia el precio sin comisión.


