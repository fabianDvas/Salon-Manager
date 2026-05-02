using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class Comision
    {
        public int ComisionId { get; set; }
        public DateTime InicioSemana { get; set; }
        public DateTime FinSemana { get; set; }
        public decimal TotalComision { get; set; }

        public int EstilistaId { get; set; }
        public Estilista Estilista { get; set; } = null!;
    }
}
