# 03. Control de Versiones del SRS — B2Market (Libros de Inglés CEC-EPN)
---

## 1. Historial de versiones y cambios

| Versión | Fecha |  Artefactos Afectados | Resumen de Cambios |
| :---: | :---: | :--- | :--- | 
| 0.1.0 | 2026-11-25 |  "01_Modelo_Casos_Uso.md", "02_Diagrama_Casos_Uso.png", "03_Historias_Usuario.md" | Borrador inicial del modelo de casos de uso, diagrama UML e historias de usuario en formato Given/When/Then. |
| 0.2.0 | 2026-11-25 |  "01_Requerimientos_Refinados.md", "01_Modelo_Casos_Uso.md", "03_Historias_Usuario.md" | Integración de requerimientos refinados ("RF-01" a "RF-06", "RNF-01" a "RNF-03", "RD-01", "RD-02"), estados (Por recibir, Disponible, Pendiente, Vendido), plazo de 24 h, confirmación en `<= 30 s` y comisión del `10 %` en efectivo. |
| 0.3.0 | 2026-11-26 |  "01_Modelo_Casos_Uso.md", "02_Diagrama_Casos_Uso.png", "03_Historias_Usuario.md" | Consolidación de CU-01 a CU-06, incorporación del actor externo "API de Pagos de sistema externo", fusión de consulta de catálogo en reserva (CU-03) y creación de CU-06 para validación de pago y entrega física. |
| 0.4.0 | 2026-11-26 |  "04_Matriz_Priorizacion_MoSCoW.md", "01_Matriz_Trazabilidad.md", "02_Resultados_Validacion.md" | Elaboración de la priorización MoSCoW con acuerdo de negociación, matriz de trazabilidad extremo a extremo, checklist de validación y registro de observaciones (OBS-01 a OBS-05) y correcciones (COR-01 a COR-05). |
| 1.0.0 | 2026-11-26 |  Paquete SRS y Modelado B2Market | Emisión de la línea base validada del SRS y modelos asociados para pasar a diseño técnico e implementación, con seguimiento de COR-05. |

---

## 4. Registro de aprobaciones

| Rol / Instancia | Nombre / Cargo | Alcance Aprobado | Estado | Fecha | Observaciones |
| :--- | :--- | :--- | :---: | :---: | :--- |
| Autor / Responsable Técnico | Dylan Haro, Katherine Tipan, Patricio Andy| Requerimientos refinados, CU-01–CU-06, "02_Diagrama_Casos_Uso.png", HU-01–HU-06, MoSCoW y Trazabilidad | Aprobado | 2026-11-26 | Línea base "1.0.0" lista; verificar enlaces del catálogo extendido (COR-05). |
| Propietario del Producto | Representante del Producto B2Market | Reglas de negocio (RD-01 comisión 10 % en efectivo, RD-02 vencimiento 24 h) y priorización MoSCoW | Aprobado | 2026-11-26 | Acuerdos de negociación documentados en "04_Matriz_Priorizacion_MoSCoW.md". |
| Operación Biblioteca CEC-EPN | Bibliotecaria (CEC-EPN) | Flujo de activación de cuentas con carné/matrícula, recepción de libros y validación de pago/entrega (CU-06) | Aprobado con observaciones | 2026-11-26 | Validado operativamente el flujo presencial y registro de incidencias tardías. |
| Administración del Sistema | Administrador B2Market | Supervisión de confirmaciones de transferencia (<= 30 s), control de duplicados y corrección de registros | Aprobado | 2026-11-26 | Conforme con las medidas de seguridad y contingencia definidas en "RNF-02" y "RF-06". |
