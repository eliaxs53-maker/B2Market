# B2Market
B2Market es una apicación de escritorio creada para ayudar a los estudiantes del Centro de Educación Continua (CEC) en la compra y venta de libros dentro de la EPN. Busca facilitar la comunicación entre vendedores y compradores, logrando un sistema de búsqueda y entrega de libros más eficiente y segura.

# Integrantes
- Katherine Tipán
- Dylan Haro
- Patricio Andy

# Problemática
Aunque los estudiantes han buscado maneras de mejorar la comunicación, la búsqueda y la oferta de libros, el proceso actual sigue generando desorden, pérdida de tiempo y confusión. Con frecuencia, las personas interesadas escriben para pedir información sobre un libro y reciben una respuesta negativa: el libro ya no está en venta o su precio excede el presupuesto.
Además, la entrega es un proceso complicado. Es necesario coordinar horarios y, muchas veces, esperar bastante tiempo para concretar el encuentro. Como las personas no se conocen, también se genera desconfianza e inseguridad, y no existe ninguna garantía de pago ni de entrega.

# Solución
B2Market centra su desarrollo apoyándose en la biblioteca de la EPN (precisamente la biblioteca que se encuentra en el mismo edificio en el que opera el CEC) como punto de custodia y entrega:
- Los vendedores publican sus libros en la aplicación y dejan el libro dentro de la biblioteca.
- Los compradores consultan el catálogo, reservan el libro por hasta 12 horas y realizan el pago mediante DeUna o en efectivo con recargo del 10%.
- Una vez pagado el sistema genera un código único de retiro para que la bibliotecaria valide y entregue el libro de forma rápida y segura.
Con esto, los vendedores harán publico su libro y no tendrán la necesidad de responder varios mensajes y cordinar la entrega del libro. En cambio, los compradores, podrán buscar el libro que necesitan de acuerdo a su presupuesto y poderlo retirar en ese mismo momento de manera segura.

# Tecnologías
- **Lenguaje / Framework:** C# (.NET / Windows Forms)
- **IDE:** Visual Studio
- **Control de versiones:** Git y GitHub

# Estructura del proyecto

```text
B2Market/
├── README.md
├── Documentacion/
│   ├── 01_Gestion_y_Alcance/
│   │   ├── 01_Vision_y_Alcance.md
│   │   └── 02_Matriz_Interesados.md
│   ├── 02_Adquisicion_e_Interesados/
│   │   ├── 01_Adquisicion_Requerimientos.md 
│   ├── 03_Catalogo_y_Refinamiento/
│   │   ├── 01_Catalogo_Requerimientos.md
│   │   ├── 02_Informe_Analisis_Refinamiento.md
│   ├── 04_Requerimientos_Verificables/
│   │   ├── 01_Requerimientos_Refinados.md
│   ├── 05_Modelado_y_Priorizacion/
│   │   ├── 01_Modelo_Casos_Uso.md
│   │   ├── 02_Diagrama_Casos_Uso.png
│   │   └── 03_Historias_Usuario.md
│   │   └── 04_Matriz_Priorizacion_MoSCoW.md
│   ├── 06_Trazabilidad_y_Validacion/      
│   │   ├── 01_Matriz_Trazabilidad.md
│   │   ├── 02_Resultados_Validacion.md
│   │   └── 03_Control_Versiones_SRS.md
│   └── SRS_Final.md                       
└── B2Market.sln                            
