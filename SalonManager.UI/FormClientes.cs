using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormClientes : Form
    {
        // Nuestra lista simulada en memoria
        private List<ClienteSimulado> _clientesSimulados = new List<ClienteSimulado>();

        public FormClientes()
        {
            InitializeComponent();
            InicializarDatosDePrueba();
        }

        // Datos de prueba (Solo con Nombre y Telefono)
        private void InicializarDatosDePrueba()
        {
            _clientesSimulados = new List<ClienteSimulado>
            {
                new ClienteSimulado { Id = 1, Nombre = "Ana Gómez", Telefono = "809-555-0192", FechaRegistro = DateTime.Now.AddDays(-10) },
                new ClienteSimulado { Id = 2, Nombre = "Juan Pérez", Telefono = "829-555-4831", FechaRegistro = DateTime.Now.AddDays(-5) },
                new ClienteSimulado { Id = 3, Nombre = "María Díaz", Telefono = "809-555-7722", FechaRegistro = DateTime.Now }
            };
        }

        // Dibuja la tabla aplicando el filtro de búsqueda
        private void ActualizarTablaClientes(string filtro = "")
        {
            var listaFiltrada = _clientesSimulados;

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                listaFiltrada = _clientesSimulados
                    .Where(c => c.Nombre.ToLower().Contains(filtro.ToLower()) || c.Telefono.Contains(filtro))
                    .ToList();
            }

            dgvClientes.DataSource = listaFiltrada.Select(c => new
            {
                ID = c.Id,
                Nombre = c.Nombre,
                Teléfono = c.Telefono,
                Registro = c.FechaRegistro.ToShortDateString()
            }).ToList();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ActualizarTablaClientes();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            ActualizarTablaClientes(txtBuscarCliente.Text);
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var ventanaRegistro = new FormClienteRegistro();

            if (ventanaRegistro.ShowDialog() == DialogResult.OK)
            {
                var nuevoCliente = ventanaRegistro.Cliente;

                bool yaExiste = _clientesSimulados.Any(c =>
                    c.Nombre.Trim().ToLower() == nuevoCliente.Nombre.Trim().ToLower() ||
                    c.Telefono.Trim() == nuevoCliente.Telefono.Trim());

                if (yaExiste)
                {
                    MessageBox.Show("¡Atención! Ya existe un cliente registrado con ese mismo nombre o número de teléfono.", "Cliente Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                nuevoCliente.Id = _clientesSimulados.Any() ? _clientesSimulados.Max(c => c.Id) + 1 : 1;
                nuevoCliente.FechaRegistro = DateTime.Now;

                _clientesSimulados.Add(nuevoCliente);
                ActualizarTablaClientes();
                MessageBox.Show("Cliente guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cliente para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);
            var clienteAEditar = _clientesSimulados.FirstOrDefault(c => c.Id == id);

            if (clienteAEditar != null)
            {
                string nombreViejo = clienteAEditar.Nombre;
                string telefonoViejo = clienteAEditar.Telefono;

                var ventanaRegistro = new FormClienteRegistro(clienteAEditar);

                if (ventanaRegistro.ShowDialog() == DialogResult.OK)
                {
                    bool duplicadoConOtro = _clientesSimulados.Any(c =>
                        c.Id != id && (
                            c.Nombre.Trim().ToLower() == clienteAEditar.Nombre.Trim().ToLower() ||
                            c.Telefono.Trim() == clienteAEditar.Telefono.Trim()
                        ));

                    if (duplicadoConOtro)
                    {
                        MessageBox.Show("No se pueden guardar los cambios. Los datos coinciden con otro cliente ya registrado.", "Error de Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clienteAEditar.Nombre = nombreViejo;
                        clienteAEditar.Telefono = telefonoViejo;
                        return;
                    }

                    ActualizarTablaClientes();
                    MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);
            string nombre = dgvClientes.CurrentRow?.Cells["Nombre"].Value?.ToString() ?? "Cliente";

            if (MessageBox.Show($"¿Eliminar al cliente '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var cliente = _clientesSimulados.FirstOrDefault(c => c.Id == id);
                if (cliente != null)
                {
                    _clientesSimulados.Remove(cliente);
                    ActualizarTablaClientes();
                    MessageBox.Show("Cliente eliminado.", "Información");
                }
            }
        }

        //  METODO PARA COMPARTIR LA LISTA CON FORM CITA - PeQueno ajuste para evitar que el FormCita tenga que acceder directamente a la lista privada
        public List<ClienteSimulado> ObtenerListaClientes()
        {
            return _clientesSimulados;
        }
    }

    public class ClienteSimulado : IEntidadSencilla
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}