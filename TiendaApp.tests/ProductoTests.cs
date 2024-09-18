using System;
using TiendaApp.Clases;
using Xunit;

namespace TiendaApp.tests
{
    public class ProductoTests
    {
        // Pruebas unitarias 

        [Fact]
        public void CrearProducto_ProductoValido_CreadoCorrectamente()      // Verifica que un producto se crea correctamente
        {
            // Arrange & Act
            var producto = new Producto("Laptop", 1000.0, "Electronics");

            // Assert
            Assert.Equal("Laptop", producto.Nombre);        // Verifica que el nombre se haya asignado correctamente
            Assert.Equal(1000.0, producto.Precio);      // Verifica que el precio se haya asignado correctamente
            Assert.Equal("Electronics", producto.Categoria);        // Verifica que la categroría se haya asignado correctamente
        }

        [Fact]
        public void CrearProducto_PrecioNegativo_LanzaArgumentException()       // Verifica si se lanza la excepción correspondiente cuando se intenta crear un producto con precio negativo
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Producto("Laptop", -100.0, "Electronics"));
        }

        [Fact]
        public void CrearProducto_NombreNulo_LanzaArgumentNullException()       // Verifica si se lanza la excepción correspondiente cuando se intenta crear un producto con el parámetro 'nombre' vacío/nulo
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Producto(null, 1000.0, "Electronics"));
        }

        [Fact]
        public void CrearProducto_CategoriaNula_LanzaArgumentNullException()        // Verifica si se lanza la excepción correspondiente cuando se intenta crear un producto con el parámetro 'categoría' vacío/nulo
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Producto("Laptop", 1000.0, null));
        }

        [Fact]
        public void ActualizarPrecio_PrecioNegativo_LanzaArgumentException()        // Verifica si se lanza la excepción correspondiente cuando se intenta actualizar el precio de un producto con un valor negativo
        {
            // Arrange
            var producto = new Producto("Laptop", 1000.0, "Electronics");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => producto.ActualizarPrecio(-500.0));
        }

    }
}
