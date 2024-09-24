using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaApp.Clases
{
    public class Tienda
    {
        private List<Producto> Inventario { get; set; }

        public Tienda()
        {
            Inventario = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            Inventario.Add(producto);
        }

        public Producto BuscarProducto(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.");

            var producto = Inventario.FirstOrDefault(p => p.Nombre == nombre);

            if (producto != null)
                return producto;

            throw new InvalidOperationException($"El producto con el nombre '{nombre}' no se encontró  en el inventario.");
        }

        public bool EliminarProducto(string nombre)
        {

            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.");

            var producto = BuscarProducto(nombre);

            return Inventario.Remove(producto);
        }

        public void AplicarDescuento(string nombre, float porcentaje)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre del producto no puede ser nulo o vacío.");

            if (porcentaje <= 0)
                throw new ArgumentException("El porcentaje no puede ser cero ni negativo.");

            if (porcentaje > 100)
                throw new ArgumentException("El porcentaje no puede ser superior a 100.");

            var producto = BuscarProducto(nombre);

            double nuevoPrecio = producto.Precio * (1 - porcentaje / 100);

            producto.ActualizarPrecio(nuevoPrecio);
        }
    }
}