using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.UI
{
    public interface IEntidadSencilla
    {
        int Id { get; set; }
        string Nombre { get; set; }
    }
}
