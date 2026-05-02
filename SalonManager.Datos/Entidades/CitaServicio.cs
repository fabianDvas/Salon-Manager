using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class CitaServicio
    {
        public int CitaId { get; set; }
        public Cita Cita { get; set; } = null!;

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;

        public decimal SubTotal { get; set; }
    }
}
