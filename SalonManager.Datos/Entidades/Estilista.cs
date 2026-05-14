using System;

namespace SalonManager.Datos.Entidades
{
    public class Estilista
    {
        // Simplificado a 'Id' para evitar errores de vinculación con la UI
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        // Columna recuperada para corregir el error de SQLite
        public string Telefono { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

    }
}