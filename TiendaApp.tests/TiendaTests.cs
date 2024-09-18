using System;
using TiendaApp.Clases;
using Xunit;

namespace TiendaApp.Tests
{
    public class TiendaTests
    {
        // Pruebas de unidad 

        [Fact]      // Prueba que no requiere parámetros. Método de prueba unitaria para ser ejecutada por XUnit
        public void AgregarProducto_ProductoValido_ProductoAgregadoCorrectamente()      // Verifica que un producto válido se agrega correctamente al inventario de la tienda y pueda ser buscado
        {
            // Arrange: preparar el entorno de prueba
            var tienda = new Tienda();
            var producto = new Producto("Laptop", 1000.0, "Electronics");

            // Act: ejecutar la prueba
            tienda.AgregarProducto(producto);

            // Assert: verificar el resultado
            var productoBuscado = tienda.BuscarProducto("Laptop");      // Busca el producto en el inventario de la tienda
            Assert.NotNull(productoBuscado);        // Verifica que el producto buscado no sea nulo
            Assert.Equal("Laptop", productoBuscado.Nombre);     // Verifica que el nombre del producto sea 'Laptop'
            Assert.Equal(1000.0, productoBuscado.Precio);        // Verifica que el precio del producto sea 1000
            Assert.Equal("Electronics", productoBuscado.Categoria);     // Verifica que la categoría del producto sea 'Electronics'
        }

        [Fact]
        public void AgregarProducto_ProductoNulo_LanzaArgumentNullException()       // Verifica que se lance la excepción si se intenta introducir un producto nulo. Verifica el manejo de errores por entradas inválidas
        {
            // Arrange
            var tienda = new Tienda();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => tienda.AgregarProducto(null));       // Se agrega un producto nulo al inventario y se verifica que se lance la excepción esperada
        }

        [Fact]
        public void BuscarProducto_ProductoExiste_ReturnsProducto()     // Verifica que un producto retorna de una búsqueda. Garantiza que un producto buscado existe
        {
            // Arrange
            var tienda = new Tienda();
            var producto = new Producto("Tablet", 500.0, "Electronics");
            tienda.AgregarProducto(producto);

            // Act
            var resultado = tienda.BuscarProducto("Tablet");

            // Assert
            Assert.NotNull(resultado);      // Verifica que el producto encontrado no sea nulo (exista)
            Assert.Equal("Tablet", resultado.Nombre);       // Verifica que el nombre del producto encontrado es 'Tablet'
        }

        [Fact]
        public void BuscarProducto_ProductoNoExiste_LanzaInvalidOperationException()        // Verifica si se lanza la excepción correspondiente si al buscarse un producto este no existe
        {
            // Arrange
            var tienda = new Tienda();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => tienda.BuscarProducto("NoExiste"));
        }

        [Fact]
        public void BuscarProducto_NombreNulo_LanzaArgumentException()      // Verifica si se lanza la excepción correspondiente si al buscar un producto con el parámetro 'nombre' vacío/nulo
        {
            // Arrange
            var tienda = new Tienda();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tienda.BuscarProducto(null));
            Assert.Throws<ArgumentException>(() => tienda.BuscarProducto(""));
        }

        [Fact]
        public void EliminarProducto_ProductoExiste_SeElimina()     // Verifica si se elimina correctamente un producto del inventario
        {
            // Arrange
            var tienda = new Tienda();
            var producto = new Producto("Smartphone", 800.0, "Electronics");
            tienda.AgregarProducto(producto);

            // Act
            var eliminado = tienda.EliminarProducto("Smartphone");      // Se invoca el método de eliminación

            // Assert
            Assert.True(eliminado);     // Verifica si el producto se ha eliminado correctamente (evalúa el valor booleano retornado por el método)
            var resultado = tienda.BuscarProducto("Smartphone");        // Realiza una nueva búsqueda del producto eliminado
            Assert.Throws<InvalidOperationException>(() => tienda.BuscarProducto("Smartphone"));        // Verifica si se lanza la correspondiente excepción al no encontrarse el producto en el inventario
        }

        [Fact]
        public void EliminarProducto_ProductoNoExiste_NoCambio()        // Verifica si al intentar eliminar un producto no existente, no se modifica el inventario
        {
            // Arrange
            var tienda = new Tienda();
            var producto = new Producto("Smartwatch", 200.0, "Electronics");
            tienda.AgregarProducto(producto);

            // Act
            var eliminado = tienda.EliminarProducto("NoExiste");        // Se invoca el método de eliminación de un producto no existente

            // Assert
            Assert.False(eliminado);        // Verifica que el resultado del intento de eliminación anterior es falso, demostrando que el método manejó el caso de la forma esperada
            var resultado = tienda.BuscarProducto("Smartwatch");        // Verifica si el producto antes añadido continúa en el inventario  
            Assert.NotNull(resultado);      // Verifica que el producto buscado exista, demostrando que el inventario no se vió afectado
        }

        [Fact]
        public void EliminarProducto_NombreNulo_LanzaArgumentException()        // Verifica si se lanza la excepción correspondiente al intentar eliminar un producto cuyo parámetro nombre es vacío/nulo
        {
            // Arrange
            var tienda = new Tienda();
            var producto = new Producto("Smartwatch", 200.0, "Electronics");
            tienda.AgregarProducto(producto);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tienda.EliminarProducto(null));
            Assert.Throws<ArgumentException>(() => tienda.EliminarProducto(""));
        }

        [Fact]
        public void BuscarProducto_SinProductos_NoEncuentra()       // Verifica la búsqueda en un inventario vacío
        {
            // Arrange
            var tienda = new Tienda();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => tienda.BuscarProducto("NoExiste"));
        }

        [Fact]
        public void EliminarProducto_SinProductos_NoCambio()        // Verifica que eliminar no afecte cuando no hay productos en el inventario
        {
            // Arrange
            var tienda = new Tienda();

            // Act
            var eliminado = tienda.EliminarProducto("NoExiste");

            // Assert
            Assert.False(eliminado);        // Verifica que el intento de eliminación falló (analiza el valor booleano retornado por el método)
        }

        [Fact]
        public void AgregarProducto_Duplicado_ProductoAgregado()        // Verifica que un producto con el mismo nombre se pueda agregar al inventario
        {
            // Arrange
            var tienda = new Tienda();
            var producto1 = new Producto("Laptop", 1000.0, "Electronics");
            var producto2 = new Producto("Laptop", 1200.0, "Electronics");
            tienda.AgregarProducto(producto1);

            // Act
            tienda.AgregarProducto(producto2);
            var productoBuscado = tienda.BuscarProducto("Laptop");

            // Assert
            Assert.NotNull(productoBuscado);        // Verifica que el producto exista
            Assert.Equal("Laptop", productoBuscado.Nombre);     // Verifica que los productos tengan el mismo nombre
            Assert.Equal(1200.0, productoBuscado.Precio);  // Asume que se actualiza el precio si hay duplicados
        }
    }
}