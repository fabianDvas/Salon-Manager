using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
     public class Inventario
    {
        public int InventarioId { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; } = 5;

        public int ProductoId { get; set; }
        public Producto Producto { get; set; } = null!;
    }
}
