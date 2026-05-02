using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class Servicio
    {
        public int ServicioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }

        public ICollection<CitaServicio> CitaServicios { get; set; } = new List<CitaServicio>();
    }
}
