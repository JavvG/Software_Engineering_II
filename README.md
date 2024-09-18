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


## 3. Uso de mocks

Se implementaron algunos métodos de prueba individual que utilizan instancias simuladas (mocks) de las clases `Producto` y `Tienda`. Se puede discutir el uso de estas entidades para hacer pruebas, puesto que en situaciones reales resulta más conveniente usar instancias reales para testear el funcionamiento de cada método, no obstante se trató de hacer una adaptación de las pruebas para el uso de mocks.

#### ¿Se pueden identificar 'Controladores' y 'Resguardos'?

En lo que va del proyecto, pueden identificarse los siguientes conceptos:

### Controladores

Son aquellas clases y métodos que se encargan de gestionar el flujo de la lógica de negocio y la interacción entre las distintas entidades. En este caso, la clase `Tienda` actúa como **controlador**, puesto que ésta se encarga de la gestión de operaciones como agregar, buscar y eliminar productos (la lógica de negocio central).

### Resguardos

Son mecanismos que se encargan de proteger la integridad de los datos y de asegurar el flujo correcto de la aplicación. Están representados por las validaciones y manejo de excepciones que garantizan el correcto funcionamiento del sistema frente a entradas o situaciones inválidas. 
En este caso, los métodos de la clase `Tienda` contienen **resguardos**, por ejemplo, cuando se realizan validaciones para evitar la inserción de productos nulos en el inventario de la tienda, o la búsqueda de productos inexistentes (métodos como `AgregarProducto` que lanza una excepción `ArgumentNullException` cuando se intenta ingresar un producto nulo, por ejemplo).

#### ¿Qué es un 'mock'? ¿Hay otros nombres para los objetos/funciones simulados?

Un **mock** es un objeto simulado, y se utiliza para realizar pruebas unitarias para representar el **comportamiento** de una clase o componente real. En esencia, es una simulación de una clase, que imita su comportamiento.
Los mocks se usan para facilitar las pruebas de componentes que tienen dependencias, ya que el programa va a utilizar los objetos simulados, en lugar de instancias reales, y así ver la interacción que tendría con otros componentes.
Otros nombres que reciben estos objetos simulados, son:

- **Fakes:** versiones simplificadas de una implementación. Reemplazan una dependendia durante las pruebas.Simulan el comportamiento de objetos reales.
- **Stubs:** objetos simulados que siempre devuelven respuestas predefinidas.
- **Spies:** objetos que permiten verificar si ciertos métodos han sido llamados y cuántas veces. Se utilizan para verificar las interacciones con un objeto.
- **Dummies:** objetos simulados que no se usan de forma activa durante las pruebas, pero que son necesarios para completar un método. Se pasan como argumentos y no se utilizan.

Algunos ejemplos que se utilizadon en este proyecto:

- `mockTienda.Setup(t => t.BuscarProducto("NombreProducto")).Returns(mockProducto.Object);`, es un ejemplo de **stub**, puesto que se configura para que siempre devuelva la misma respuesta.
- `mockTienda.Verify(t => t.BuscarProducto("NombreProducto"), Times.Once);`, si bien es un **stub**, también tiene un comportamiento **spy**.