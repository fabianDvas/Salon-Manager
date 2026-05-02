using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public enum EstadoCita { Pendiente, Completada, Cancelada }

    public class Cita
    {
        public int CitaId { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int EstilistaId { get; set; }
        public Estilista Estilista { get; set; } = null!;

        public ICollection<CitaServicio> CitaServicios { get; set; } = new List<CitaServicio>();
    }
}
