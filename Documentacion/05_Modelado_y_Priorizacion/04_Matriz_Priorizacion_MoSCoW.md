# 04. Matriz de Priorización MoSCoW — B2Market (Libros de Inglés CEC-EPN)
## 1. Matriz de priorización

| ID | Requerimiento / Elemento | Categoría MoSCoW | Casos de Uso / HU Asociados | Justificación de prioridad |
| :--- | :--- | :---: | :---: | :--- |
| RF-01 | Registro e inicio de sesión con validación de cuenta por bibliotecaria | Must | "CU-01" / "HU-01" | Controla el acceso y verifica el vínculo con el CEC-EPN mediante carné o matrícula. |
| RF-02| Publicación de libros con validación de precio (> 0), fotografía y estado "Por recibir" | Must | "CU-02" / "HU-02" | Permite ingresar libros al flujo de venta evitando datos inválidos o sin evidencia visual. |
| RF-03| Consulta del catálogo con libros recibidos y sus 7 datos principales | Must | "CU-03" / "HU-03" | Evita mostrar libros no recibidos en biblioteca y garantiza información completa para elegir. |
| RF-04 | Reserva de libro "Disponible" a "Pendiente", bloqueo de doble reserva y elección de pago | Must | "CU-03" / "HU-04" | Evita reservas duplicadas o auto-reservas y organiza el paso de pago. |
| RF-05| Solicitud de código de pago por transferencia a la API con contingencia (reintento / efectivo) | Must | "CU-04" / "HU-05" | Habilita el flujo de transferencia y ofrece salida si el servicio externo falla. |
| RF-06 | Confirmación de transferencia en <= 30 s, sin duplicados y registro de incidencias tardías | Must | "CU-05", "CU-06" /"HU-05", "HU-06" | Garantiza consistencia del estado "Vendido" y previene ventas duplicadas o fuera de tiempo. |
| RD-02 | Plazo de vencimiento de reserva por transferencia a 24 horas | Must | "CU-04", "CU-05" / "HU-04", "HU-05" | Define la regla temporal de vigencia del comprobante/código de transferencia. |
| RNF-02 | Protección de datos (hash + sal, TLS 1.2+, cierre por 5 min de inactividad y privacidad de cobro) | Must | Transversal (`RF-01` a `RF-06`) | Protege credenciales, comunicaciones y datos sensibles de pago y cobranza. |
| RNF-01 | Usabilidad de reserva en máximo 5 clics y 2 minutos para usuarios nuevos | Should | "CU-03" / "HU-03", "HU-04" | Mejora la experiencia y adopción del comprador, pero no bloquea la lógica funcional base. |
| RNF-03 | Disponibilidad >= 99 % del horario mensual de atención de la biblioteca | Should | Transversal del sistema | Asegura continuidad operativa durante el horario de atención sin frenar el modelado inicial. |
|*RD-01 | Comisión del 10 % en pagos en efectivo destinada a la bibliotecaria | Should | "CU-03", "CU-06" / "HU-04", "HU-06" | Regla de negocio relevante para el cobro presencial, priorizada tras estabilizar el ciclo central. |

---

## 3. Acuerdo de negociación documentado

* Contexto de la negociación: Reunión de alineación entre el equipo de desarrollo, el propietario del producto, la operación de biblioteca (CEC-EPN) y la administración del sistema B2Market para equilibrar alcance, tiempos de entrega y reglas del dominio.
* Acuerdos alcanzados:
  1. Blindaje del núcleo transaccional (`Must`): Se acordó que `RF-01` a `RF-06`, `RD-02` y `RNF-02` son no negociables para la primera entrega funcional, asegurando el ciclo "Por recibir" / "Disponible" / "Pendiente" / "Vendido", la ventana de 24 horas, la respuesta en máximo 30 segundos ante confirmaciones y las medidas de seguridad.
  2. Tratamiento de requisitos "Should" ("RNF-01", "RNF-03", "RD-01"): Se consensuó mantenerlos activos en el alcance del proyecto con prioridad secundaria frente a los "Must", validando la usabilidad en pruebas con usuarios, monitoreando la disponibilidad en horario de biblioteca y aplicando la regla de comisión del 10 % en efectivo sin alterar las ventas por transferencia.
  3. Manejo de contingencias y bordes: Cualquier confirmación de transferencia recibida tras vencer las 24 horas o repetida no generará una segunda venta; las tardías quedarán registradas como incidencia para revisión administrativa/bibliotecaria. Si la API de pagos falla al generar el código, el comprador podrá reintentar o continuar por efectivo.
  4. Control de cambios: Cualquier modificación posterior a los requisitos marcados como "Must" o a las reglas de estados ("Por recibir", "Disponible", "Pendiente", "Vendido") requerirá acuerdo explícito de las partes y actualización conjunta de requerimientos, casos de uso, historias de usuario y esta matriz.
