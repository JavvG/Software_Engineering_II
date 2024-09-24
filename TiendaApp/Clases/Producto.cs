using System;

namespace TiendaApp.Clases
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }

        public Producto(string nombre, double precio, string categoria)
        {
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");        // 'ArgumentException': excepció que se lanza ante un argumento inv lido

            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo.");     // 'ArgumentNullException': excepción que se lanza ante un argumento nulo
            Precio = precio;
            Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria), "La categor a no puede ser nula.");
        }

        public virtual void ActualizarPrecio(double nuevoPrecio)
        {
            if (nuevoPrecio < 0)
                throw new ArgumentException("El nuevo precio no puede ser negativo.");

            Precio = nuevoPrecio;
        }
    }
}