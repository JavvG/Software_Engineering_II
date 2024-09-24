using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaApp.Clases
{
    public class TiendaFixture
    {
        public Tienda Tienda { get; private set; }

        public TiendaFixture()
        {
            // Inicializamos la tienda y posteriormente se agregan 3 productos
            Tienda = new Tienda();
            Producto producto_1 = new Producto("Producto A", 100.0, "Categoria 1");
            Producto producto_2 = new Producto("Producto B", 200.0, "Categoria 2");
            Producto producto_3 = new Producto("Producto C", 300.0, "Categoria 3");
            Tienda.AgregarProducto(producto_1);
            Tienda.AgregarProducto(producto_2);
            Tienda.AgregarProducto(producto_3);
        }
    }
}
