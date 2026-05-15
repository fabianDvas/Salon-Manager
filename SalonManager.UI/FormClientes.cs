using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SalonManager.Datos;
using SalonManager.Datos.Entidades;

namespace SalonManager.UI
{
    public partial class FormClientes : Form
    {
        
        private readonly SalonDbContext _context;
        public FormClientes(SalonDbContext context)
        {
            InitializeComponent();
            _context = context;
        }



        private void ActualizarTablaClientes(string filtro = "")
        {
            // Traemos los clientes reales de la base de datos
            var consulta = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                // Filtramos por nombre o teléfono en la base de datos
                consulta = consulta.Where(c => c.Nombre.Contains(filtro) || c.Telefono.Contains(filtro));
            }

            // Pasamos los datos a la tabla (DataGridView)
            dgvClientes.DataSource = consulta.Select(c => new
            {
                c.ClienteId,
                c.Nombre,
                c.Telefono
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

                // VALIDACIÓN REAL: ¿Existe en la Base de Datos?
                bool yaExiste = _context.Clientes.Any(c =>
                    c.Nombre.ToLower() == nuevoCliente.Nombre.ToLower() ||
                    c.Telefono == nuevoCliente.Telefono);

                if (yaExiste)
                {
                    MessageBox.Show("¡Atención! Ya existe un cliente con ese nombre o teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // GUARDAR EN BD
                _context.Clientes.Add(nuevoCliente);
                _context.SaveChanges();

                ActualizarTablaClientes();
                MessageBox.Show("Cliente guardado con éxito.", "Éxito");
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);
            var clienteAEditar = _context.Clientes.Find(id); // Busca directo en la BD

            if (clienteAEditar != null)
            {
                var ventanaRegistro = new FormClienteRegistro(clienteAEditar);

                if (ventanaRegistro.ShowDialog() == DialogResult.OK)
                {
                    // Validar que al editar no choque con otro cliente existente
                    bool duplicado = _context.Clientes.Any(c =>
                        c.ClienteId != id && (c.Nombre == clienteAEditar.Nombre || c.Telefono == clienteAEditar.Telefono));

                    if (duplicado)
                    {
                        MessageBox.Show("Error: Los datos ya pertenecen a otro cliente.");
                        return;
                    }

                    _context.SaveChanges(); // Guarda los cambios del objeto editado
                    ActualizarTablaClientes();
                }
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);
            var cliente = _context.Clientes.Find(id);

            if (cliente != null)
            {
                if (MessageBox.Show($"¿Eliminar a {cliente.Nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    ActualizarTablaClientes();
                }
            }
        }

        //  METODO PARA COMPARTIR LA LISTA CON FORM CITA - PeQueno ajuste para evitar que el FormCita tenga que acceder directamente a la lista privada
        public List<Cliente> ObtenerListaClientes()
        {
            return _context.Clientes.ToList(); ;
        }
    }

    
}