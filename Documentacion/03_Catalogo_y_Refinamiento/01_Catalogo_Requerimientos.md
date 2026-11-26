# 01. Catálogo de Requerimientos - B2Market

B2Market funciona en las computadoras de la biblioteca del CEC-EPN y solo lo usan estudiantes del CEC-EPN para comprar y vender libros. La bibliotecaria y el administrador participan con funciones operativas.

## Tabla de requerimientos

| ID | Requerimiento | Tipo | Nivel | Fuente | Estado |
|---|---|---|---|---|---|
| RF-01 | El sistema permitirá registrarse e iniciar sesión solo a estudiantes del CEC-EPN, con cuenta activada por la bibliotecaria. | Funcional | Usuario | Propietario | Por validar |
| RF-02 | El vendedor podrá publicar un libro con título, autor, nivel, descripción, precio mayor a cero y foto; quedará `Por recibir`. | Funcional | Usuario | Vendedor | Por validar |
| RF-03 | El comprador podrá consultar los libros ya recibidos en la biblioteca y ver su detalle. | Funcional | Usuario | Comprador | Por validar |
| RF-04 | El comprador podrá reservar un libro ajeno y `Disponible`; pasará a `Pendiente` y elegirá el método de pago. | Funcional | Usuario | Comprador, propietario | Refinado |
| RF-05 | El sistema generará un código de pago por transferencia mediante la API; si falla, permitirá reintentar o pagar en efectivo. | Funcional | Sistema | Propietario, entidad de pagos | Condicionado |
| RF-06 | El sistema marcará el libro como `Vendido` en máximo 30 segundos tras confirmarse el pago, sin duplicados ni pagos vencidos. | Funcional | Sistema | Administrador, vendedor | Condicionado |
| RNF-01 | Un usuario nuevo podrá reservar un libro sin ayuda, en máximo 5 clics y 2 minutos desde la pantalla de inicio. | No funcional | Sistema | Comprador, vendedor | Refinado |
| RNF-02 | El sistema usará contraseñas con hash y sal, conexiones cifradas, cierre a los 5 minutos de inactividad y acceso restringido a los datos de cobro. | No funcional | Sistema | Autoridades, entidad de pagos | Por validar |
| RNF-03 | El sistema estará disponible al menos el 99 % del horario de atención de la biblioteca. | No funcional | Sistema | Administrador, autoridades | Refinado |
| RD-01 | La comisión del 10 % se aplica solo al pago en efectivo, la paga el comprador y la recibe la bibliotecaria. | Dominio | Usuario | Propietario | Analizado |
| RD-02 | La reserva dura 24 horas desde que se genera el código o comprobante. | Dominio | Usuario | Propietario | Analizado |

## Estados

- **Propuesto:** idea registrada que aún no se analiza.
- **Analizado:** revisado y sin cambios.
- **Refinado:** corregido o agregado después del análisis.
- **Por validar:** incluye una decisión que falta aprobar.
- **Condicionado:** depende de cómo se resuelva el pago con DeUna.


