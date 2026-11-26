# Matriz de Interesados — B2Market

## 1. Tabla de interesados

| Interesado | Clasificación | Interés | Influencia | Necesidad principal |
|---|---|---|---|---|
| **Comprador** (estudiante de la EPN o CEC) | Interno a la EPN/CEC; directo | Alto (Conseguir libros de forma rápida, segura y económica) | Alta | Buscar un libro y adquirirlo con facilidad según sus preferencias |
| **Vendedor** | Interno a la EPN/CEC; directo | Alto (Vender sus libros y recibir su dinero) | Alta | Publicar fácilmente y recibir el pago de manera segura y eficiente |
| **Bibliotecaria** | Interno; directo | Media (Tener una tarea manejable y recibir compensación únicamente por los cobros físicos | Media | Código claro del libro, acceso preferencial en el sistema y retribución económica por pagos físicos |
| **Administrador del sistema** (equipo desarrollador) | Interno; directo | Alto (Un sistema que opere con mínima intervención) | Alta | Mantener la integridad de los estados (`Disponible`, `Pendiente`, `Vendido`), automatizar la liberación de reservas y asegurar la estabilidad de la aplicación en los equipos de biblioteca |
| **Entidad de pagos** (API de DeUna) | Externo; indirecto | Medio (Uso correcto de su servicio) | Media | ue la integración cumpla sus especificaciones técnicas para generar códigos de cobro y emitir notificaciones válidas de confirmación de pago |
| **Autoridades de la universidad o biblioteca** | Interno; indirecto | Alto (Que el servicio no afecte el funcionamiento ni la imagen de la biblioteca) | Alta | Asegurar el uso adecuado de las computadoras de la biblioteca, mantener el orden en los espacios físicos y respetar los reglamentos y horarios institucionales |
| **Autoridad tributaria (SRI)** | Externo; indirecto | Baja (Cumplimiento de obligaciones por las comisiones (por confirmar si aplica)) | Baja | Registro claro de las comisiones cobradas |

## 2. Conflictos entre interesados y su resolución

### Conflicto 1: Comprador vs. Bibliotecaria (comisión del pago físico)

# 02. Matriz de Interesados — B2Market

## 1. Matriz de Interesados

| Interesado | Clasificación | Interés | Influencia | Necesidades / Expectativas |
| :--- | :--- | :--- | :--- | :--- |
| **Estudiante Comprador (CEC)** | Usuario final (Interno; directo) | Alto | Alta | Consultar libros disponibles del CEC, reservar un ejemplar de forma segura y pagar mediante transferencia (DeUna) o en efectivo sin demoras ni engaños. |
| **Estudiante Vendedor (CEC)** | Usuario final (Interno; directo) | Alto | Alta | Publicar sus libros con descripción, fotografías y precio, dejarlos en custodia en biblioteca y recibir el pago íntegro sin que su libro quede bloqueado indefinidamente. |
| **Bibliotecaria** | Usuario operativo / Custodio (Interno; directo) | Medio | Media | Contar con un procedimiento sencillo para recibir libros, validar comprobantes mediante el código del libro, marcar como `Vendido` los pagos físicos y recibir compensación por el cobro en efectivo. |
| **Administrador del Sistema (Equipo Desarrollador)** | Equipo técnico / Operador (Interno; directo) | Alto | Alta | Mantener la integridad de los estados (`Disponible`, `Pendiente`, `Vendido`), automatizar la liberación de reservas y asegurar la estabilidad de la aplicación en los equipos de biblioteca. |
| **Autoridades de la Universidad / Biblioteca (EPN - CEC)** | Autoridad institucional (Interno; indirecto) | Alto | Alta | Asegurar el uso adecuado de las computadoras de la biblioteca, mantener el orden en los espacios físicos y respetar los reglamentos y horarios institucionales. |
| **Entidad de Pagos (API DeUna)** | Proveedor / Sistema externo (Externo; indirecto) | Medio | Media | Que la integración cumpla sus especificaciones técnicas para generar códigos de cobro y emitir notificaciones válidas de confirmación de pago. |
| **Autoridad Tributaria (SRI)** | Ente regulador (Externo; indirecto) | Bajo | Baja | Trazabilidad y transparencia en el registro de transacciones y comisiones cobradas dentro de la plataforma (sujeto a revisión normativa). |

---

## 2. Conflictos Identificados y Resolución

| N.° | Partes involucradas | Conflicto | Estrategia de resolución |
| :--- | :--- | :--- | :--- |
| **1** | **Comprador vs. Bibliotecaria** | El comprador que paga en efectivo no desea asumir costos adicionales al precio del libro, mientras que la bibliotecaria requiere compensación por recibir el dinero y gestionar el trámite presencial. | Se establece una comisión del **10%** únicamente en pagos físicos, exigiendo que el sistema muestre el valor adicional y solicite aceptación explícita antes de confirmar, dejando siempre disponible la transferencia vía DeUna con **0% de comisión**. |
| **2** | **Comprador vs. Vendedor** | El comprador busca el mayor tiempo posible para acercarse a pagar su reserva, pero el vendedor necesita evitar que su ejemplar quede retenido sin venderse si el pago no se concreta. | Se fija un bloqueo máximo de **24 horas** contadas desde la generación del código o comprobante de pago; si transcurrido ese tiempo no hay pago confirmado, el libro vuelve automáticamente a estado `Disponible`. |
| **3** | **Usuarios vs. Autoridades de Biblioteca** | Los estudiantes podrían esperar acceso remoto desde sus dispositivos o disponibilidad continua 24/7, lo cual entra en conflicto con las políticas de seguridad y horarios físicos de la biblioteca. | Se define como restricción del sistema que la aplicación opera exclusivamente en las computadoras autorizadas de la biblioteca y durante su horario oficial de atención. |
| **4** | **Comprador vs. Entidad de Pagos (API DeUna)** | Una falla o demora temporal de la API de pagos puede impedir generar el código de transferencia o confirmar la transacción en el momento. | Ante errores de comunicación con la API, el sistema notifica al usuario y ofrece reintentar la operación o cambiar a pago físico con aviso previo de la comisión correspondiente. |
