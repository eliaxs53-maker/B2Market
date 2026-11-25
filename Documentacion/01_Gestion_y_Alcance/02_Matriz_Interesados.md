# Matriz de Interesados — B2Market

# 1. Tabla de interesados

| Interesado | Clasificación | Interés | Influencia | Necesidad principal |
| **Comprador**| Interno o externo a la universidad; directo | Conseguir libros de forma segura y a buen precio | Alta | Reservar un libro y pagar con facilidad |
| **Vendedor** | Interno o externo; directo | Vender sus libros y recibir su dinero completo | Alta | Publicar fácilmente y recibir el pago íntegro |
| **Bibliotecaria** | Interno; directo | Tener una tarea manejable y recibir compensación por los cobros físicos | Media | Código claro del libro y herramienta simple para marcarlo como Vendido |
| **Administrador del sistema** (equipo desarrollador) | Interno; directo | Un sistema que opere con mínima intervención | Alta | Reglas automáticas de reserva y liberación, y control de estados |
| **Entidad de pagos** (API de DeUna) | Externo; indirecto | Uso correcto de su servicio | Media | Integración conforme a su documentación |
| **Autoridades de la universidad o biblioteca** | Interno; indirecto | Que el servicio no afecte el funcionamiento ni la imagen de la biblioteca | Alta | Control del uso de los equipos y de los cobros |
| **Autoridad tributaria (SRI)** | Externo; indirecto | Cumplimiento de obligaciones por las comisiones (por confirmar si aplica) | Baja | Registro claro de las comisiones cobradas |

## 2. Conflictos entre interesados y su resolución

### Conflicto 1: Comprador vs. Bibliotecaria (comisión del pago físico)

| Paso | Detalle |
|---|---|
| **Identificación** | El pago físico implica un costo extra que afecta al comprador y beneficia a la bibliotecaria. |
| **Documentación** | **Comprador:** desea no pagar costos adicionales. **Bibliotecaria:** debe ser compensada por recibir el dinero y atender el trámite. |
| **Revisión de reglas** | El propietario definió que la transferencia no tiene comisión y el pago físico sí (10 % del precio). |
| **Negociación** | La comisión existe solo en el pago físico, se muestra al comprador antes de confirmar y se puede evitar eligiendo transferencia. |
| **Transformación en requerimiento** | RF-08 (aviso de comisión con aceptación explícita) y RD-01 (comisión solo en pago físico). |

### Conflicto 2: Comprador vs. Vendedor (tiempo de bloqueo del libro)

| Paso | Detalle |
|---|---|
| **Identificación** | El comprador quiere más tiempo para pagar; el vendedor no quiere que su libro quede bloqueado indefinidamente. |
| **Documentación** | **Comprador:** necesita un plazo razonable para pagar. **Vendedor:** necesita que el libro vuelva a estar disponible si no se paga. |
| **Revisión de reglas** | El propietario definió un bloqueo de 24 horas, contadas desde que se genera el comprobante o código de pago. |
| **Negociación** | Se acuerda un límite fijo de 24 horas; pasado ese tiempo sin pago, el sistema libera el libro automáticamente. |
| **Transformación en requerimiento** | RD-02 (bloqueo de 24 horas) y RF-10 (liberación automática del libro). |
