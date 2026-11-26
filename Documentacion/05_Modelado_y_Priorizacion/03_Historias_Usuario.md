# Historias de Usuario — Sistema de Compra de Libros de Inglés (cec)
##HU-01: Publicación de libro en el catálogo
* Historia: Como Vendedor se quiere registrar un libro con su nivel de inglés del CEC, detalles, precio e imagen, para ponerlo a la venta en el catálogo del sistema
* Requerimiento asociado: RF-01 — Registro y validación de publicaciones de libros (`CU-01`).
* **Criterios de aceptación:**
  * **Escenario 1 (Publicación exitosa):**
    * **Given** que el vendedor ha iniciado sesión y completa título, nivel del CEC, descripción, precio mayor a `$0.00` e imagen válida,
    * **When** hace clic en publicar/guardar,
    * **Then** el sistema guarda el libro en estado `"Disponible"` y lo muestra en el catálogo.
  * **Escenario 2 (Datos incompletos o precio inválido):**
    * **Given** que el vendedor omite un campo obligatorio o ingresa un precio menor o igual a `$0.00`,
    * **When** intenta guardar la publicación,
    * **Then** el sistema impide el registro y muestra un mensaje indicando qué dato corregir.
