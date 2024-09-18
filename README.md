# Trabajo Práctico Nro. 1
#### Ingeniería de Software II

## 1. Pruebas realizadas

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
