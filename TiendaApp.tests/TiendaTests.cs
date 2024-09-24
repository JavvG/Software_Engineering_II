using System;
using TiendaApp.Clases;
using Xunit;
using Moq;

namespace TiendaApp.Tests
{
    
    public class TiendaTests : IClassFixture<TiendaFixture>
    {

        private  Tienda _tienda;

        //Inicializacion del Fixture de Tienda en entorno de Pruebas
        public TiendaTests(TiendaFixture fixture)
        {
            _tienda = fixture.Tienda;
        }

        // Pruebas de unidad 

        [Fact]      // Prueba que no requiere parámetros. Método de prueba unitaria para ser ejecutada por XUnit
        public void AgregarProducto_ProductoValido_ProductoAgregadoCorrectamente()      // Verifica que un producto válido se agrega correctamente al inventario de la tienda y pueda ser buscado
        {
            // Arrange: preparar el entorno de prueba
            
            var producto = new Producto("Laptop", 1000.0, "Electronics");

            // Act: ejecutar la prueba
            _tienda.AgregarProducto(producto);  // Utilizacion de Fixture de Tienda

            // Assert: verificar el resultado
            var productoBuscado = _tienda.BuscarProducto("Laptop");      // Busca el producto en el inventario de la tienda
            Assert.NotNull(productoBuscado);        // Verifica que el producto buscado no sea nulo
            Assert.Equal("Laptop", productoBuscado.Nombre);     // Verifica que el nombre del producto sea 'Laptop'
            Assert.Equal(1000.0, productoBuscado.Precio);        // Verifica que el precio del producto sea 1000
            Assert.Equal("Electronics", productoBuscado.Categoria);     // Verifica que la categoría del producto sea 'Electronics'
        }

        [Fact]
        public void AgregarProducto_ProductoNulo_LanzaArgumentNullException()       // Verifica que se lance la excepción si se intenta introducir un producto nulo. Verifica el manejo de errores por entradas inválidas
        {

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _tienda.AgregarProducto(null));       // Se agrega un producto nulo al inventario y se verifica que se lance la excepción esperada
        }

        [Fact]
        public void BuscarProducto_ProductoExiste_ReturnsProducto()     // Verifica que un producto retorna de una búsqueda. Garantiza que un producto buscado existe
        {
            // Arrange
            var producto = new Producto("Tablet", 500.0, "Electronics");
            _tienda.AgregarProducto(producto);

            // Act
            var resultado = _tienda.BuscarProducto("Tablet");

            // Assert
            Assert.NotNull(resultado);      // Verifica que el producto encontrado no sea nulo (exista)
            Assert.Equal("Tablet", resultado.Nombre);       // Verifica que el nombre del producto encontrado es 'Tablet'
        }

        [Fact]
        public void BuscarProducto_ProductoNoExiste_LanzaInvalidOperationException()        // Verifica si se lanza la excepción correspondiente si al buscarse un producto este no existe
        {

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _tienda.BuscarProducto("NoExiste"));
        }

        [Fact]
        public void BuscarProducto_NombreNulo_LanzaArgumentException()      // Verifica si se lanza la excepción correspondiente si al buscar un producto con el parámetro 'nombre' vacío/nulo
        {

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _tienda.BuscarProducto(null));
            Assert.Throws<ArgumentException>(() => _tienda.BuscarProducto(""));
        }

        [Fact]
        public void EliminarProducto_ProductoExiste_SeElimina()     // Verifica si se elimina correctamente un producto del inventario
        {
            // Arrange

            var producto = new Producto("Smartphone", 800.0, "Electronics");
            _tienda.AgregarProducto(producto);

            // Act
            var eliminado = _tienda.EliminarProducto("Smartphone");      // Se invoca el método de eliminación

            // Assert
            Assert.True(eliminado);     // Verifica si el producto se ha eliminado correctamente (evalúa el valor booleano retornado por el método)                   
            Assert.Throws<InvalidOperationException>(() => _tienda.BuscarProducto("Smartphone"));        // Verifica si se lanza la correspondiente excepción al no encontrarse el producto en el inventario
        }

        [Fact]
        public void EliminarProducto_ProductoNoExiste_NoCambio()        // Verifica si al intentar eliminar un producto no existente, no se modifica el inventario
        {
            // Arrange
            var producto = new Producto("Smartwatch", 200.0, "Electronics");
            _tienda.AgregarProducto(producto);   

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _tienda.BuscarProducto("NoExiste"));        // Verifica si se lanza la correspondiente excepción al no encontrarse el producto en el inventario
            var resultado = _tienda.BuscarProducto("Smartwatch");        // Verifica si el producto antes añadido continúa en el inventario  
            Assert.NotNull(resultado);      // Verifica que el producto buscado exista, demostrando que el inventario no se vió afectado
        }

        [Fact]
        public void EliminarProducto_NombreNulo_LanzaArgumentException()        // Verifica si se lanza la excepción correspondiente al intentar eliminar un producto cuyo parámetro nombre es vacío/nulo
        {
            // Arrange
            var producto = new Producto("Smartwatch", 200.0, "Electronics");
            _tienda.AgregarProducto(producto);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _tienda.EliminarProducto(null));
            Assert.Throws<ArgumentException>(() => _tienda.EliminarProducto(""));
        }

        [Fact]
        public void BuscarProducto_SinProductos_NoEncuentra()       // Verifica la búsqueda en un inventario vacío
        {

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _tienda.BuscarProducto("NoExiste"));
        }

        [Fact]
        public void EliminarProducto_SinProductos_NoCambio()        // Verifica que eliminar no afecte cuando no hay productos en el inventario
        {

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _tienda.EliminarProducto("NoExiste"));        // Verifica que el intento de eliminación falló y que se lanzó la excepción correspondiente al no encontrarse el producto
        }

        [Fact]
        public void AgregarProducto_Duplicado_ProductoAgregado()        // Verifica que un producto con el mismo nombre se pueda agregar al inventario
        {
            // Arrange
            var producto1 = new Producto("Laptop", 1000.0, "Electronics");
            var producto2 = new Producto("Laptop", 1200.0, "Electronics");
            _tienda.AgregarProducto(producto1);

            // Act
            _tienda.AgregarProducto(producto2);
            var productoBuscado = _tienda.BuscarProducto("Laptop");

            // Assert
            Assert.NotNull(productoBuscado);        // Verifica que el producto exista
            Assert.Equal("Laptop", productoBuscado.Nombre);     // Verifica que los productos tengan el mismo nombre
            Assert.Equal(1200.0, productoBuscado.Precio);  // Asume que se actualiza el precio si hay duplicados
        }

        // Pruebas unitarias usando instancias simuladas de clases (mocks)

        [Fact]
        public void AplicarDescuento_DeberiaActualizarPrecioDelProductoMock()       // Prueba que verifica que el método 'ActualizarPrecio' del mock se llama correctamente con el nuevo valor de precio.
        {
            // Arrange: preparación del entorno de prueba
            var mockProducto = new Mock<Producto>("NombreProducto", 100.0, "Categoria");        // Se crea una instancia simulada (mock) de la clase 'Producto'

            _tienda.AgregarProducto(mockProducto.Object);        // El mock del producto se añade al inventario del Fixture de Tienda

            // Act: ejecución de la prueba
            _tienda.AplicarDescuento("NombreProducto", (float)10.0);     // Se invoca el método para aplicar el descuento usando el nombre del mock del producto y el porcentaje de descuento

            // Assert: verifica que el método ActualizarPrecio fue llamado en el mock con el nuevo precio esperado
            mockProducto.Verify(p => p.ActualizarPrecio(It.IsInRange(89.99, 90.01, Moq.Range.Inclusive)), Times.Once);      // Se usa sobrecarga del método Verify() para comparar los valores con una tolerancia
        }

        [Fact]
        public void AgregarProducto_ConMock_DeberiaAgregarProductoAlInventarioMock()        // Verifica que el método 'AgregarProducto' se llama con el mock de Producto como parámetro. 
                                                                                            // En un entorno de prueba real, creo que sería más conveniente testear con instancias reales en lugar de mocks
        {
            // Arrange: se preparan dos mocks, uno para la clase 'Producto' y otro para 'Tienda'
            var mockProducto = new Mock<Producto>("NombreProducto", 100.0, "Categoria");
            var mockTienda = new Mock<Tienda>();

            // Act
            mockTienda.Object.AgregarProducto(mockProducto.Object);

            // Assert
            mockTienda.Verify(t => t.AgregarProducto(mockProducto.Object), Times.Once);     // Se verifica que el método AgregarProducto se haya llamado desde el mock de 'Tienda' con el mock de 'Producto' como parámetro, una única vez
        }

        [Fact]
        public void BuscarProducto_ConMock_DeberiaDevolverProductoDelInventarioMock()       // Verifica que el método 'BuscarProducto' devuelve el producto correcto usando un mock.
        {
            // Arrange
            var mockProducto = new Mock<Producto>("NombreProducto", 100.0, "Categoria");
            var mockTienda = new Mock<Tienda>();

            mockTienda.Setup(t => t.BuscarProducto("NombreProducto")).Returns(mockProducto.Object);     // Se configura el mock de 'Tienda' para que retorne el mock de 'Producto' cuando se invoque el método de búsqueda

            // Act
            var productoBuscado = mockTienda.Object.BuscarProducto("NombreProducto");

            // Assert
            Assert.NotNull(productoBuscado);        // Verifica que el producto no sea nulo
            Assert.Equal("NombreProducto", productoBuscado.Nombre);         // Verifica que el nombre sea el esperado
            mockTienda.Verify(t => t.BuscarProducto("NombreProducto"), Times.Once);         // Verifica que el método se llame una única vez 
        }

        [Fact]
        public void EliminarProducto_ConMock_DeberiaEliminarProductoMock()              // Verifica que el método 'EliminarProducto' se llama correctamente en el mock de la tienda.
                                                                                        // En condiciones reales, creo que debería probarse con instancias reales
        {
            // Arrange
            var mockProducto = new Mock<Producto>("ProductoAEliminar", 100.0, "Categoria");
            var mockTienda = new Mock<Tienda>();

            mockTienda.Object.AgregarProducto(mockProducto.Object);

            // Act
            mockTienda.Object.EliminarProducto("ProductoAEliminar");

            // Assert
            mockTienda.Verify(t => t.EliminarProducto("ProductoAEliminar"), Times.Once);        // Verifica que el método de eliminación se invoca desde el mock de 'Tienda' con el nombre del mock de 'Producto' como parámetro, una única vez
        }
    }
}