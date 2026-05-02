using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
