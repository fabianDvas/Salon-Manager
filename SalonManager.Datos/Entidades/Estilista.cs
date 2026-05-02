using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class Estilista
    {
        public int EstilistaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal PorcentajeComision { get; set; }

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<Comision> Comisiones { get; set; } = new List<Comision>();
    }
}
