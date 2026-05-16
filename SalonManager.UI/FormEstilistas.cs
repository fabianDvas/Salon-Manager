using Microsoft.Data.Sqlite;
using SalonManager.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormEstilistas : Form
    {
        private readonly SalonDbContext _context;
        public FormEstilistas(SalonDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        // 1. CARGA DE DATOS: Con validación de existencia de columnas
        private void ActualizarTablaEstilistas(string filtro = "")
        {
            List<EstilistaSimulado> listaDesdeDB = new List<EstilistaSimulado>();

            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM Estilistas";

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        command.CommandText += " WHERE Nombre LIKE $f OR Especialidad LIKE $f";
                        command.Parameters.AddWithValue("$f", $"%{filtro}%");
                    }

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaDesdeDB.Add(new EstilistaSimulado
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? "" : reader.GetString(reader.GetOrdinal("Nombre")),
                                // Si la columna no existiera por error de EF, esto lanzaría una excepción controlada
                                Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                                Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? "" : reader.GetString(reader.GetOrdinal("Especialidad"))
                            });
                        }
                    }
                }

                dgvEstilistas.DataSource = null;
                dgvEstilistas.DataSource = listaDesdeDB.Select(e => new
                {
                    ID = e.Id,
                    Nombre = e.Nombre,
                    Teléfono = e.Telefono,
                    Especialidad = e.Especialidad
                }).ToList();
            }
            catch (Exception ex)
            {
                // Si llegas aquí con el error de "Telefono", es que la clase Estilista en Datos no ha sido actualizada
                MessageBox.Show("Aviso de Estructura: " + ex.Message, "Sincronización de Base de Datos");
            }
        }

        private void FormEstilistas_Load(object sender, EventArgs e)
        {
            ActualizarTablaEstilistas();
        }

        private void txtBuscarEstilista_TextChanged(object sender, EventArgs e)
        {
            ActualizarTablaEstilistas(txtBuscarEstilista.Text);
        }

        // 2. AGREGAR: Con el mapeo corregido de Telefono
        private void btnAgregarEstilista_Click(object sender, EventArgs e)
        {
            var ventanaRegistro = new FormEstilistaRegistro();

            if (ventanaRegistro.ShowDialog() == DialogResult.OK)
            {
                var nuevo = ventanaRegistro.Estilista;
                if (nuevo == null || string.IsNullOrWhiteSpace(nuevo.Nombre)) return;

                try
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        var insert = connection.CreateCommand();

                        // Aseguramos que el comando use @ para parámetros estándar de SQLite
                        insert.CommandText = "INSERT INTO Estilistas (Nombre, Telefono, Especialidad) VALUES (@n, @t, @e)";
                        insert.Parameters.AddWithValue("@n", nuevo.Nombre.Trim());
                        insert.Parameters.AddWithValue("@t", nuevo.Telefono ?? "");
                        insert.Parameters.AddWithValue("@e", nuevo.Especialidad ?? "");

                        insert.ExecuteNonQuery();
                    }

                    ActualizarTablaEstilistas();
                    MessageBox.Show("Estilista guardado correctamente.", "Éxito");
                }
                catch (Exception ex)
                {
                    // Si sale el error de "no column named Telefono", revisa la clase Estilista en el proyecto de Datos
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error de Base de Datos");
                }
            }
        }

        // 3. EDITAR
        private void btnEditarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["ID"].Value);
            EstilistaSimulado? estilistaAEditar = null;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Estilistas WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        estilistaAEditar = new EstilistaSimulado
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                            Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? "" : reader.GetString(reader.GetOrdinal("Especialidad"))
                        };
                    }
                }
            }

            if (estilistaAEditar != null)
            {
                var ventanaRegistro = new FormEstilistaRegistro(estilistaAEditar);

                if (ventanaRegistro.ShowDialog() == DialogResult.OK)
                {
                    using (var connection = DatabaseHelper.GetConnection())
                    {
                        connection.Open();
                        var updateCmd = connection.CreateCommand();
                        updateCmd.CommandText = "UPDATE Estilistas SET Nombre = @n, Telefono = @t, Especialidad = @e WHERE Id = @id";
                        updateCmd.Parameters.AddWithValue("@n", ventanaRegistro.Estilista.Nombre);
                        updateCmd.Parameters.AddWithValue("@t", ventanaRegistro.Estilista.Telefono);
                        updateCmd.Parameters.AddWithValue("@e", ventanaRegistro.Estilista.Especialidad);
                        updateCmd.Parameters.AddWithValue("@id", id);
                        updateCmd.ExecuteNonQuery();
                    }
                    ActualizarTablaEstilistas();
                }
            }
        }

        // 4. ELIMINAR
        private void btnEliminarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["ID"].Value);
            string nombre = dgvEstilistas.CurrentRow.Cells["Nombre"].Value?.ToString() ?? "Estilista";

            if (MessageBox.Show($"¿Eliminar a {nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Estilistas WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                ActualizarTablaEstilistas();
            }
        }

        public List<EstilistaSimulado> ObtenerListaEstilistas()
        {
            List<EstilistaSimulado> lista = new List<EstilistaSimulado>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Estilistas";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new EstilistaSimulado
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? "" : reader.GetString(reader.GetOrdinal("Telefono")),
                            Especialidad = reader.IsDBNull(reader.GetOrdinal("Especialidad")) ? "" : reader.GetString(reader.GetOrdinal("Especialidad"))
                        });
                    }
                }
            }
            return lista;
        }

       
    }

    // El modelo interno debe tener la propiedad Telefono para evitar errores de compilación
    public class EstilistaSimulado : IEntidadSencilla
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty; // Asegurado
        public string Especialidad { get; set; } = string.Empty;
    }
}