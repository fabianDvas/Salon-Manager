using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SalonManager.UI
{
    public partial class FormCita : Form
    {
        private List<IEntidadSencilla>? _clientes;
        private List<IEntidadSencilla>? _estilistas;
        private int? _idCitaSeleccionada = null;

        public FormCita(IEnumerable<IEntidadSencilla> clientes, IEnumerable<IEntidadSencilla> estilistas)
        {
            InitializeComponent();
            _clientes = clientes.ToList();
            _estilistas = estilistas.ToList();

            CargarCombos();
            ActualizarTablaCitas();
        }

        private void CargarCombos()
        {
            if (_clientes != null)
            {
                cmbCliente.DataSource = null;
                cmbCliente.DataSource = _clientes;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "Id";
                cmbCliente.SelectedIndex = -1;
            }

            if (_estilistas != null)
            {
                cmbEstilista.DataSource = null;
                cmbEstilista.DataSource = _estilistas;
                cmbEstilista.DisplayMember = "Nombre";
                cmbEstilista.ValueMember = "Id";
                cmbEstilista.SelectedIndex = -1;
            }

            cmbHora.Items.Clear();
            cmbHora.Items.AddRange(new string[] {
                "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM",
                "02:00 PM", "03:00 PM", "04:00 PM", "05:00 PM"
            });

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Completada");
            cmbEstado.Items.Add("Cancelada");
            cmbEstado.SelectedIndex = 0;
        }

        private void ActualizarTablaCitas()
        {
            List<CitaSimulada> listaCitas = new List<CitaSimulada>();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Cliente, Fecha, Hora, Estilista, Estado FROM Citas";

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaCitas.Add(new CitaSimulada
                            {
                                Id = reader.GetInt32(0),
                                Cliente = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Fecha = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                Hora = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Estilista = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Estado = reader.IsDBNull(5) ? "" : reader.GetString(5)
                            });
                        }
                    }
                }
                catch { }
            }

            // Ajustes importantes para evitar problemas de columnas de FormCitas
            dataGridView1.Columns.Clear(); 
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = listaCitas; // Asigna los datos nuevos

            if (dataGridView1.Columns.Count > 0)
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // EVENTO: GUARDAR / ACTUALIZAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 || cmbEstilista.SelectedIndex == -1 || string.IsNullOrEmpty(cmbHora.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Atención");
                return;
            }

            var cliente = (IEntidadSencilla)cmbCliente.SelectedItem!;
            var estilista = (IEntidadSencilla)cmbEstilista.SelectedItem!;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();

                if (_idCitaSeleccionada == null)
                {
                    command.CommandText = @"INSERT INTO Citas (Cliente, Fecha, Hora, Estilista, Estado) 
                                            VALUES ($cli, $fec, $hor, $est, $estd)";
                }
                else
                {
                    command.CommandText = @"UPDATE Citas SET Cliente=$cli, Fecha=$fec, Hora=$hor, 
                                            Estilista=$est, Estado=$estd WHERE Id=$id";
                    command.Parameters.AddWithValue("$id", _idCitaSeleccionada);
                }

                command.Parameters.AddWithValue("$cli", cliente.Nombre);
                command.Parameters.AddWithValue("$fec", dtpFecha.Value.ToShortDateString());
                command.Parameters.AddWithValue("$hor", cmbHora.Text);
                command.Parameters.AddWithValue("$est", estilista.Nombre);
                command.Parameters.AddWithValue("$estd", cmbEstado.Text);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("Operación realizada con éxito.");
            _idCitaSeleccionada = null;
            btnGuardar.Text = "Guardar";
            LimpiarFormulario();
            ActualizarTablaCitas(); // Refresca la tabla inmediatamente
        }

        // EVENTO: EDITAR (Carga los datos de la tabla a los campos de arriba)
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita de la lista para editar.");
                return;
            }

            // Obtenemos el ID de la fila seleccionada
            var cellId = dataGridView1.CurrentRow.Cells["Id"].Value;
            if (cellId != null) _idCitaSeleccionada = Convert.ToInt32(cellId);

            // Cargamos los valores a los controles
            cmbCliente.Text = dataGridView1.CurrentRow.Cells["Cliente"].Value?.ToString() ?? "";
            cmbEstilista.Text = dataGridView1.CurrentRow.Cells["Estilista"].Value?.ToString() ?? "";

            string? fechaStr = dataGridView1.CurrentRow.Cells["Fecha"].Value?.ToString();
            if (DateTime.TryParse(fechaStr, out DateTime fechaCita)) dtpFecha.Value = fechaCita;

            cmbHora.Text = dataGridView1.CurrentRow.Cells["Hora"].Value?.ToString() ?? "";
            cmbEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value?.ToString() ?? "Pendiente";

            btnGuardar.Text = "Actualizar Cita"; // Cambia el texto del botón para indicar edición
        }

        // EVENTO: ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita para eliminar.");
                return;
            }

            var cellId = dataGridView1.CurrentRow.Cells["Id"].Value;
            if (cellId == null) return;

            int id = Convert.ToInt32(cellId);

            if (MessageBox.Show("¿Está seguro de que desea eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM Citas WHERE Id = $id";
                    cmd.Parameters.AddWithValue("$id", id);
                    cmd.ExecuteNonQuery();
                }

                ActualizarTablaCitas(); // Refresca la tabla tras eliminar
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            cmbCliente.SelectedIndex = -1;
            cmbEstilista.SelectedIndex = -1;
            cmbHora.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Now;
        }

        private void panel3_Paint(object sender, PaintEventArgs e) { }

        public class CitaSimulada
        {
            public int Id { get; set; }
            public string Cliente { get; set; } = string.Empty;
            public string Fecha { get; set; } = string.Empty;
            public string Hora { get; set; } = string.Empty;
            public string Estilista { get; set; } = string.Empty;
            public string Estado { get; set; } = string.Empty;
        }
    }
}