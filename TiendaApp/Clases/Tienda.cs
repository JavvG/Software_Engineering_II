using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaApp.Clases
{
    public class Tienda
    {
        private List<Producto> Inventario { get; set; }

        private List<String> Carrito { get; set; }

        public Tienda()
        {
            Inventario = new List<Producto>();
            Carrito = new List<String>();
        }

        public virtual void AgregarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            try
            {
                var productoExistente = BuscarProducto(producto.Nombre);
                productoExistente.ActualizarPrecio(producto.Precio);        // Si el prpducto ya existe en los registros, se actualiza el precio
            }
            catch (InvalidOperationException)
            {
                Inventario.Add(producto);
            }
        }

        public virtual Producto BuscarProducto(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre no puede ser nulo o vacío.");

            var producto = Inventario.FirstOrDefault(p => p.Nombre == nombre);

            if (producto != null)
                return producto;

            throw new InvalidOperationException($"El producto con el nombre '{nombre}' no se encontró  en el inventario.");
        }

        public virtual bool EliminarProducto(string nombre)
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

        public void AgregarAlCarrito(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("El nombre del producto no puede ser nulo o vacío.");

            var nombreProducto = BuscarProducto(nombre).Nombre;

            Carrito.Add(nombreProducto);
        }

        public void VaciarCarrito()
        {
            Carrito.Clear(); // Método para vaciar el carrito
        }


        public double CalcularTotalCarrito()
        {
            if (Carrito == null || !Carrito.Any())
            {
                throw new ArgumentException("La lista de nombres de productos no puede ser nula o vacía.");
            }

            double total = 0;

            foreach(var nombre in Carrito)
            {
                var producto = BuscarProducto(nombre);
                total += producto.Precio;
            }

            return total;
        }
    }
}