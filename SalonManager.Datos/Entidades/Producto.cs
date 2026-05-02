using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal PrecioCompra { get; set; }

        public Inventario? Inventario { get; set; }
    }
}
