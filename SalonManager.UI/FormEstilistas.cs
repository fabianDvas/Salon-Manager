using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SalonManager.Datos; 
using SalonManager.Datos.Entidades;

namespace SalonManager.UI
{
    public partial class FormEstilistas : Form
    {
        private readonly SalonDbContext _context;

        // Constructor que recibe la base de datos
        public FormEstilistas(SalonDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void ActualizarTablaEstilistas(string filtro = "")
        {
            var consulta = _context.Estilistas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                consulta = consulta.Where(e => e.Nombre.Contains(filtro) || e.Especialidad.Contains(filtro));
            }

            dgvEstilistas.DataSource = consulta.Select(e => new
            {
                ID = e.Id,
                e.Nombre,
                Teléfono = e.Telefono,
                e.Especialidad
            }).ToList();
        }

        private void FormEstilistas_Load(object sender, EventArgs e)
        {
            ActualizarTablaEstilistas();
        }
        private void txtBuscarEstilista_TextChanged(object sender, EventArgs e)
        {
            ActualizarTablaEstilistas(txtBuscarEstilista.Text);
        }

        private void btnAgregarEstilista_Click(object sender, EventArgs e)
        {
            var ventanaRegistro = new FormEstilistaRegistro();

            if (ventanaRegistro.ShowDialog() == DialogResult.OK)
            {
                var nuevo = ventanaRegistro.Estilista;

                //validacion
                bool telefonoExiste = _context.Estilistas.Any(e => e.Telefono == nuevo.Telefono);

                if (telefonoExiste && !string.IsNullOrWhiteSpace(nuevo.Telefono))
                {
                    MessageBox.Show("Ya existe un estilista con ese número de teléfono.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _context.Estilistas.Add(nuevo);
                _context.SaveChanges();
                ActualizarTablaEstilistas();
            }
        }

        private void btnEditarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            var estilistaAEditar = _context.Estilistas.Find(id);

            if (estilistaAEditar != null)
            {
                var ventanaRegistro = new FormEstilistaRegistro(estilistaAEditar);

                if (ventanaRegistro.ShowDialog() == DialogResult.OK)
                {
                    // Validar teléfono duplicado (que no sea el de él mismo)
                    bool duplicado = _context.Estilistas.Any(e => e.Id != id && e.Telefono == estilistaAEditar.Telefono);

                    if (duplicado && !string.IsNullOrWhiteSpace(estilistaAEditar.Telefono))
                    {
                        MessageBox.Show("No se pudo actualizar: El teléfono ya pertenece a otro estilista.");
                        return;
                    }

                    _context.SaveChanges();
                    ActualizarTablaEstilistas();
                }
            }
        }

        private void btnEliminarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["Id"].Value);
            var estilista = _context.Estilistas.Find(id);

            if (estilista != null)
            {
                if (MessageBox.Show($"¿Eliminar a {estilista.Nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _context.Estilistas.Remove(estilista);
                    _context.SaveChanges();
                    ActualizarTablaEstilistas();
                }
            }
        }

        public List<Estilista> ObtenerListaEstilistas()
        {
            return _context.Estilistas.ToList();
        }

    
    }
}