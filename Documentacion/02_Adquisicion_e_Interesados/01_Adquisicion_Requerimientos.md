# 01. Adquisición de Requerimientos — B2Market

## 1. Plan de Adquisición

El proceso de obtención de información se estructuró aplicando diversas técnicas de elicitación adaptadas a cada fuente de información dentro del Centro de Educación Continua (CEC) de la EPN:

| Técnica de elicitación | Fuente / Interesado | Propósito / Información esperada | Responsable | Cronograma estimado |
| :--- | :--- | :--- | :--- | :--- |
| **Entrevista semiestructurada y observación** | Bibliotecaria del CEC | Conocer el flujo físico de recepción, custodia y entrega de libros, tiempos de verificación de comprobantes, espacio disponible y postura ante el cobro de comisión en pagos físicos. | Katherine Tipán | Semana 1 (Días 1–2) |
| **Encuesta y prototipo inicial** | Estudiantes compradores (CEC) | Identificar métodos de pago preferidos, tiempos de espera aceptables para reservas y datos mínimos del libro que desean visualizar. | Patricio Andy | Semana 1 (Días 2–4) |
| **Taller (grupo focal)** | Estudiantes vendedores (CEC) | Contrastar expectativas sobre la publicación de ejemplares (fotos, precio), temores sobre bloqueos prolongados y mecanismo de recepción del pago. | Dylan Haro | Semana 1 (Días 3–5) |
| **Análisis documental** | Documentación de la API de pagos (DeUna) | Verificar capacidades técnicas, formato de generación de códigos de cobro, notificaciones automáticas de confirmación y posibles costos. | Katherine Tipán / Dylan Haro | Semana 2 (Días 1–2) |
| **Entrevista y revisión normativa** | Autoridades de la biblioteca / CEC y Docente (Propietario) | Validar permisos de uso de las computadoras de la biblioteca, horarios de atención y reglas de negocio oficiales del sistema. | Patricio Andy / Katherine Tipán | Semana 2 (Días 2–3) |

---

## 2. Tabla de Información Registrada

A continuación se documentan los registros consolidados durante la fase de adquisición (10 registros base con su respectiva fuente y aclaración):

| ID | Información obtenida | Fuente | Aclaración / Detalle operativo |
| :--- | :--- | :--- | :--- |
| **101** | La aplicación se usa únicamente en las computadoras de la biblioteca. | Propietario / Autoridades de biblioteca | Restringe el acceso remoto; los estudiantes deben acudir físicamente en el horario de atención de la biblioteca. |
| **102** | Los usuarios inician sesión con una cuenta propia vinculada al CEC (correo institucional o personal registrado). | Propietario | El acceso está acotado exclusivamente a estudiantes del CEC, evitando el ingreso de público externo ajeno a la institución. |
| **103** | Una misma cuenta puede publicar y comprar libros. | Propietario | No se requieren perfiles separados; cada estudiante tiene doble rol (comprador y vendedor) desde su única cuenta. |
| **104** | El vendedor publica información del libro, fotografías y precio. | Vendedor / Propietario | Para evitar publicaciones incompletas, se exige título, autor, descripción, precio mayor a cero y al menos una fotografía. |
| **105** | Al pulsar *"Quiero comprar"*, el libro pasa a estado `Pendiente` y queda reservado. | Propietario / Comprador | Impide que otro estudiante reserve o compre el mismo ejemplar mientras el proceso de pago está activo. |
| **106** | El pago por transferencia se genera con la API de DeUna; no tiene comisión y el dinero llega al vendedor. | Propietario / Documentación de la API | Al confirmarse el pago mediante notificación de la API, el sistema cambia el libro a `Vendido` de forma automática. |
| **107** | El pago físico genera un comprobante y una comisión adicional para la bibliotecaria; el resto es del vendedor. | Propietario / Bibliotecaria | La comisión equivale al **10% del precio del libro**, asumida por el comprador tras aceptar el aviso previo en pantalla. |
| **108** | Solo la bibliotecaria puede marcar como `Vendido` los libros pagados en físico, ingresando el código. | Propietario / Bibliotecaria | La bibliotecaria opera con una cuenta administrativa limitada y el sistema bloquea cambios manuales en libros pagados por transferencia. |
| **109** | La compra iniciada bloquea el libro por 24 horas; luego vuelve a estar `Disponible`. | Propietario / Vendedor | El plazo de **24 horas** se contabiliza exactamente desde el momento en que se genera el código o comprobante de pago. |
| **110** | Los vendedores entregan los libros a la bibliotecaria, quien los custodia y entrega al comprador. | Bibliotecaria | La entrega física se realiza únicamente presentando el comprobante con el código único del libro una vez confirmado el pago. |

---

## 3. Preguntas de Aclaración y Respuestas Obtenidas

Durante la verificación inicial se detectaron declaraciones ambiguas que fueron consultadas y aclaradas con el propietario y la bibliotecaria:

1. **Sobre la comisión en pagos físicos:**
   * **Pregunta:** *¿La comisión por pago físico es un valor fijo o un porcentaje del precio? ¿Quién la paga y cuál es su monto?*
   * **Respuesta obtenida:** Es un porcentaje equivalente al **10% sobre el precio del libro**, pagado adicionalmente por el comprador. Este monto queda a favor de la bibliotecaria como compensación por la gestión de cobro en efectivo, mientras el precio íntegro del libro corresponde al vendedor. El sistema debe mostrar este desglose antes de confirmar la compra.

2. **Sobre el inicio del conteo de las 24 horas de bloqueo:**
   * **Pregunta:** *¿Las 24 horas de reserva se cuentan desde que el comprador pulsa "Quiero comprar" o desde que se genera el código o comprobante de pago?*
   * **Respuesta obtenida:** Se cuentan a partir del instante en que se genera el código de pago (transferencia) o el comprobante de pago (físico). Si transcurridas las 24 horas no se registra confirmación, el libro retorna automáticamente a estado `Disponible`.

3. **Sobre el mecanismo de entrega del dinero al vendedor en pagos físicos:**
   * **Pregunta:** *Cuando un comprador paga en efectivo a la bibliotecaria, ¿cómo recibe el vendedor su dinero (en efectivo directamente en biblioteca o mediante transferencia)?*
   * **Respuesta obtenida (acuerdo operativo):** El sistema registra por separado el monto íntegro a favor del vendedor y la comisión del 10% a favor de la bibliotecaria, dejando constancia en el comprobante para su liquidación directa en biblioteca al cierre o retiro.

---

## 4. Registro de Conflictos Detectados

| ID Conflicto | Interesados involucrados | Descripción del conflicto | Resolución acordada | Estado |
| :--- | :--- | :--- | :--- | :--- |
| **CONF-01** | Comprador vs. Bibliotecaria | El comprador que elige pagar en efectivo no desea pagar recargos adicionales, mientras que la bibliotecaria requiere compensación por recibir el dinero y atender el cobro presencial. | Se mantiene la comisión del **10%** únicamente para pagos físicos, mostrándola de forma transparente antes de confirmar y ofreciendo pago por transferencia (DeUna) con **0% de comisión**. | **Resuelto** |
| **CONF-02** | Comprador vs. Vendedor | El comprador busca disponer del mayor plazo posible para acercarse a pagar su reserva, mientras que el vendedor necesita evitar que su ejemplar permanezca bloqueado indefinidamente sin venderse. | Se establece un límite fijo de **24 horas** desde la generación del código o comprobante de pago, tras el cual el sistema libera automáticamente el libro a `Disponible`. | **Resuelto** |
| **CONF-03** | Usuarios vs. Autoridades de Biblioteca | Los estudiantes podrían esperar acceso remoto desde sus dispositivos o disponibilidad continua 24/7, lo cual choca con las normas de uso de equipos y horarios físicos de la biblioteca. | Se acota el funcionamiento de la aplicación exclusivamente a las computadoras autorizadas dentro de la biblioteca y durante su horario oficial de atención. | **Resuelto** |
