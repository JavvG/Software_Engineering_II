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

            if (producto == null)
                throw new InvalidOperationException($"El producto con el nombre '{nombre}' no se encontró  en el inventario.");

            return producto;
        }

        public bool EliminarProducto(string nombre)
        {

            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.");

            var producto = BuscarProducto(nombre);

            return Inventario.Remove(producto);
        }
    }
}