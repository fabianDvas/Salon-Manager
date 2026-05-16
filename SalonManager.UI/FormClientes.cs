using Microsoft.EntityFrameworkCore;
using SalonManager.Datos;
using SalonManager.Datos.Entidades; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        // Ahora consulta a la Base de Datos Real
        private void ActualizarTablaClientes(string filtro = "")
        {
            // Traemos los clientes de la DB
            var query = _context.Clientes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(c => c.Nombre.ToLower().Contains(filtro.ToLower()) ||
                                         c.Telefono.Contains(filtro));
            }

            dgvClientes.DataSource = query.Select(c => new
            {
                ID = c.ClienteId,
                Nombre = c.Nombre,
                Teléfono = c.Telefono,
                Registro = DateTime.Now.ToShortDateString()
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
            // Usamos la inicialización que evita errores de diseño
            var ventanaRegistro = new FormClienteRegistro(new Cliente());

            if (ventanaRegistro.ShowDialog() == DialogResult.OK)
            {
                var clienteDeVentana = ventanaRegistro.Cliente;

                // ---  VALIDACIÓN ---
                bool yaExiste = _context.Clientes.Any(c =>
                    c.Nombre.ToLower() == clienteDeVentana.Nombre.ToLower() ||
                    c.Telefono == clienteDeVentana.Telefono);

                if (yaExiste)
                {
                    MessageBox.Show("¡Atención! Ya existe un cliente con ese nombre o teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detiene el guardado si es un duplicado
                }

                // Creamos la entidad limpia para la base de datos
                var nuevoCliente = new Cliente
                {
                    Nombre = clienteDeVentana.Nombre,
                    Telefono = clienteDeVentana.Telefono
                };

                // Guardar en Base de Datos de forma segura
                _context.Clientes.Add(nuevoCliente);
                _context.SaveChanges();

                ActualizarTablaClientes();
                MessageBox.Show("Cliente guardado en la base de datos con éxito.", "Éxito");
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);

            if (MessageBox.Show($"¿Eliminar al cliente seleccionado?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    ActualizarTablaClientes();
                }
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ID"].Value);
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
    }
}