# 02. Resultados de Validación — B2Market (Libros de Inglés CEC-EPN)

## 1. Información general de la validación

* Proyecto / Sistema: B2Market — Sistema de compra y venta de libros de inglés del CEC-EPN.
* Artefactos evaluados: Requerimientos refinados (`RF-01` a `RF-06`, `RNF-01` a `RNF-03`, `RD-01`, `RD-02`), Modelo de Casos de Uso (`01_Modelo_Casos_Uso.md`), Diagrama de Casos de Uso (`02_Diagrama_Casos_Uso.png`), Historias de Usuario (`03_Historias_Usuario.md`), Matriz de Priorización MoSCoW (`04_Matriz_Priorizacion_MoSCoW.md`) y Matriz de Trazabilidad (`01_Matriz_Trazabilidad.md`).
* Participantes de la revisión: Equipo de desarrollo , representación de operación de biblioteca (CEC-EPN) y propietario del producto.
* Objetivo: Verificar que los requerimientos y modelos sean completos, consistentes, no ambiguos, verificables y trazables antes de iniciar la fase de implementación.

---

## 2. Checklist de validación de requerimientos y modelos

| N.º | Criterio de Validación | Estado | Evidencia / Verificación realizada |
| :---: | :--- | :---: | :--- |
| 01 | Completitud: Todos los actores, estados del libro (Por recibir, Disponible, Pendiente, Vendido) y reglas de negocio están cubiertos. | Cumple | Se incluyen los 4 actores (Vendedor, Comprador, Bibliotecaria, Administrador), el sistema externo (API de Pagos) y todo el ciclo de vida del libro. |
| 02 | Consistencia entre artefactos: Los identificadores y flujos coinciden entre requerimientos, casos de uso, diagrama UML e historias de usuario. | Cumple | Existe correspondencia directa entre "RF-01..RF-06", "CU-01..CU-06" y "HU-01..HU-06", usando los mismos estados y condiciones. |
| 03 | No ambigüedad: Las reglas temporales, porcentajes y umbrales están expresados de forma exacta y medible. | Cumple | Se especifican valores exactos: precio "> 0", plazo de reserva de "24 horas", confirmación en máximo `30 segundos`, sesión inactiva "5 minutos" y comisión de "10 %" en efectivo. |
| 04 | Verificabilidad / Testabilidad: Cada requerimiento cuenta con criterios de aceptación objetivos y pruebas propuestas. | Cumple | Todos los "RF", "RNF" y "RD" poseen criterios de aceptación observables y casos de prueba definidos en la matriz de trazabilidad. |
| 05 | Trazabilidad bidireccional: Cada requerimiento tiene origen (fuente), caso de uso, historia de usuario y prioridad MoSCoW asignada. | Cumple | Documentado en "01_Matriz_Trazabilidad.md" y "04_Matriz_Priorizacion_MoSCoW.md" sin requerimientos huérfanos. |
| 06 | Factibilidad técnica y operativa: Las interacciones con la biblioteca y la API de pagos son realizables y contemplan fallos. | Cumple | `RF-05` y `RF-06` definen contingencias explícitas ante fallos de API, confirmaciones duplicadas y confirmaciones tardías. |
| 07 | Notación UML correcta: El diagrama respeta límite del sistema, actores externos, óvalos de casos de uso y asociaciones. | Cumple | "02_Diagrama_Casos_Uso.png" delimita el sistema B2Market y diferencia el actor externo "API de Pagos de sistema externo". |
| 08 | Consistencia de dependencias cruzadas: Todas las referencias internas entre fichas ("RF", "RNF", "RD") existen en el catálogo completo. | Observación | En "RF-02", "RF-03", "RF-04" y "RNF-03" se citan identificadores extendidos ("RF-11", "RF-16", "RF-18", "RD-03", "RD-04") que deben mantenerse sincronizados con el catálogo maestro. |

---

## 3. Observaciones detectadas durante la revisión

1. OBS-01 — Desfase inicial en estados del libro y flujo de publicación: En los borradores iniciales de casos de uso, un libro publicado pasaba directamente a "Disponible", omitiendo el estado intermedio "Por recibir" definido en "RF-02" y "RF-03" (necesario hasta que el ejemplar llegue físicamente a biblioteca).
2. OBS-02 — Regla de comisión y flujo de pago en efectivo: Inicialmente se planteó que la bibliotecaria ejecutara una transferencia al vendedor al cobrar en efectivo; al contrastar con "RF-05", "RF-06" y "RD-01", se precisó que la API gestiona los códigos de transferencia (con vencimiento de 24 h) y que el pago en efectivo aplica una comisión del "10 %" destinada a la bibliotecaria.
3. OBS-03 — Granularidad de casos de uso y rol de la bibliotecaria: La consulta del catálogo ("RF-03") estaba separada como un caso de uso aislado en lugar de integrarse en el flujo de compra/reserva, mientras que faltaba explicitar la validación presencial de pago y entrega física realizada por la bibliotecaria ("CU-06").
4. OBS-04 — Validación de pertenencia al CEC-EPN: La restricción de usuarios pertenecientes al CEC-EPN estaba ubicada como flujo alternativo dentro de la compra, cuando según "RF-01" se controla desde el registro y activación de cuenta por parte de la bibliotecaria al revisar el carné o matrícula.
5. OBS-05 — Referencias a requerimientos complementarios del catálogo general: Algunas fichas de requerimientos refinados mencionan dependencias ("RF-11", "RF-16", "RF-18", "RD-03", "RD-04") pertenecientes al catálogo extendido del proyecto.

---

## 4. Correcciones derivadas y estado de cierre

| ID Obs. | Acción correctiva aplicada | Artefactos actualizados | Estado |
| :---: | :--- | :--- | :---: |
| COR-01 | Se incorporó el estado inicial "Por recibir" en el flujo principal y postcondiciones de CU-02, ocultando dichos ejemplares del catálogo de compra (CU-03 / HU-03) hasta su recepción en biblioteca. | "01_Modelo_Casos_Uso.md", "03_Historias_Usuario.md" | Cerrada |
|COR-02 | Se alinearon CU-04, CU-05 y CU-06 con la generación de código vía API (plazo 24 h), confirmación en "<= 30 s" sin duplicados y cobro en efectivo con comisión del "10 %" para la bibliotecaria. | "01_Modelo_Casos_Uso.md", "03_Historias_Usuario.md", "04_Matriz_Priorizacion_MoSCoW.md" | Cerrada |
| COR-03 | Se integró la consulta del catálogo dentro de CU-03 (Reserva de libro) y se incorporó CU-06 (Validación de pago y entrega de libro) junto con el actor externo "API de Pagos de sistema externo". | "01_Modelo_Casos_Uso.md", "02_Diagrama_Casos_Uso.png", "03_Historias_Usuario.md" | Cerrada |
| COR-04 | Se trasladó la verificación de carné/matrícula del CEC-EPN a `CU-01` / `HU-01` (`RF-01`) como requisito previo de activación de cuenta antes de operar en el sistema. | "01_Modelo_Casos_Uso.md", "03_Historias_Usuario.md" | Cerrada |
| COR-05* | Se verificó en "01_Matriz_Trazabilidad.md` la cobertura completa de los requerimientos activos ("RF-01..RF-06", "RNF-01..RNF-03", "RD-01..RD-02") y se dejó documentada la revisión de enlaces con el catálogo extendido antes de codificar. | "01_Matriz_Trazabilidad.md" | En seguimiento |

---

## 5. Dictamen de validación

La documentación de requerimientos, modelado UML, historias de usuario, priorización MoSCoW y trazabilidad de B2Market se considera APROBADA CON OBSERVACIÓN MENOR (COR-05), quedando lista para servir de línea base en la fase de diseño técnico e implementación del sistema.
