# Trabajo Práctico Nro. 1
#### Ingeniería de Software II

## 1. Pruebas básicas realizadas

### Pruebas de unidad
Se implementaron pruebas de unidad para las clases `Producto` y `Tienda`, enfocándose en validar el comportamiento de estas clases de manera aislada. Las pruebas cubren los siguientes casos:

- **Producto**:
  - Verificación de la correcta creación de un producto.
  - Validación de las restricciones para nombre nulo, categoría nula y precios negativos.

- **Tienda**:
  - Agregar un producto válido y verificar su presencia en el inventario.
  - Manejo de errores al intentar agregar productos nulos.
  - Búsqueda de productos existentes y no existentes.
  - Eliminación de productos y verificación de su correcta eliminación.

### Pruebas de integración
Aunque las pruebas de la clase `Tienda` incluyen interacción con la clase `Producto`, **no se consideran pruebas de integración completas**. Estas pruebas solo evalúan el funcionamiento interno entre clases dentro del mismo módulo de la aplicación, sin interacción con otros subsistemas o servicios externos como bases de datos o APIs.

Para que las pruebas sean consideradas **pruebas de integración**, deben involucrar la interacción entre diferentes componentes del sistema (como bases de datos, APIs u otros servicios). En este caso, las pruebas se limitan a validar las interacciones dentro del dominio del código, sin componentes externos. Por lo tanto, no cumplen con los criterios de una prueba de integración.

## 2. Pruebas con excepciones

Adicionalmente, se implementaron pruebas de unidad a las clases `Producto` y `Tienda` para verificar el manejo adecuado de excepciones en cada método de cada clase.

### Escribir las pruebas antes del código (Test-Driven Development - TDD)

#### ¿Podrían haberse escrito las pruebas primero antes de modificar el código de la aplicación?

Sí, en el enfoque TDD (Diseño Guiado por Pruebas, en español), se escribe primero una prueba que falle (porque la funcionalidad aún no está implementada) y luego se implementa la funcionalidad necesaria para que la prueba pase. Este proceso se repite para cada nueva funcionalidad o cambio en el código. 

El proceso para escribir primero las pruebas, siguiendo el enfoque TDD, es el siguiente:

#### 1. Escribir una prueba que falle

Se escribe una prueba que defina cómo debería comportarse la nueva funcionalidad o el manejo de excepciones. Esta prueba fallará inicialmente porque la funcionalidad no ha sido implementada aún.

#### 2. Implementar el código mínimo necesario

Después de escribir la prueba, se debe implementar el código mínimo necesario para que la prueba sea efectiva. Esta implementación está diseñada para cumplir con los requisitos especificados en la prueba.

#### 3. Refactorizar

Una vez que la prueba pasa, se puede refactorizar el código mínimo escrito para mejorar su calidad, pero sin cambiar su funcionalidad. La refactorización asegura que el código sea limpio y eficiente.

#### 4. Repetir el proceso

Los pasos anteriores deben repetirse para cada nueva funcionalidad o modificaciones en el código que deba ser probado. Cada nueva funcionalidad debe ser probada mediante el enfoque TDD para garantizar que el código cumpla con los requisitos especificados y funcione correctamente.