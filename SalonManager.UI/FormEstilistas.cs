using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormEstilistas : Form
    {
        private List<EstilistaSimulado> _estilistasSimulados;

        public FormEstilistas()
        {
            InitializeComponent();
            InicializarDatosEstilistas();
        }

        private void InicializarDatosEstilistas()
        {
            _estilistasSimulados = new List<EstilistaSimulado>
            {
                new EstilistaSimulado { Id = 1, Nombre = "Carlos Ruiz", Telefono = "809-111-2222", Especialidad = "Corte Varón" },
                new EstilistaSimulado { Id = 2, Nombre = "Elena Marte", Telefono = "829-333-4444", Especialidad = "Tinte y Color" },
                new EstilistaSimulado { Id = 3, Nombre = "Sofia Luna", Telefono = "809-555-6666", Especialidad = "Manicura" }
            };
        }

        private void ActualizarTablaEstilistas(string filtro = "")
        {
            var lista = _estilistasSimulados;

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                lista = _estilistasSimulados
                    .Where(e => e.Nombre.ToLower().Contains(filtro.ToLower()) || e.Especialidad.ToLower().Contains(filtro.ToLower()))
                    .ToList();
            }

            dgvEstilistas.DataSource = lista.Select(e => new
            {
                ID = e.Id,
                Nombre = e.Nombre,
                Teléfono = e.Telefono,
                Especialidad = e.Especialidad
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

        // BOTÓN AGREGAR (CON VALIDACIÓN DE DUPLICADOS)
        private void btnAgregarEstilista_Click(object sender, EventArgs e)
        {
            var ventanaRegistro = new FormEstilistaRegistro();

            if (ventanaRegistro.ShowDialog() == DialogResult.OK)
            {
                var nuevoEstilista = ventanaRegistro.Estilista;

                // 🔍 VALIDACIÓN: ¿Ya existe un estilista con el mismo nombre o teléfono?
                bool yaExiste = _estilistasSimulados.Any(x =>
                    x.Nombre.Trim().ToLower() == nuevoEstilista.Nombre.Trim().ToLower() ||
                    x.Telefono.Trim() == nuevoEstilista.Telefono.Trim());

                if (yaExiste)
                {
                    MessageBox.Show(
                        "¡Atención! Ya existe un estilista registrado con ese nombre o número de teléfono.",
                        "Estilista Duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Si pasa la validación, generamos su ID y lo agregamos
                nuevoEstilista.Id = _estilistasSimulados.Any() ? _estilistasSimulados.Max(x => x.Id) + 1 : 1;
                _estilistasSimulados.Add(nuevoEstilista);
                ActualizarTablaEstilistas();
                MessageBox.Show("Estilista registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // BOTÓN EDITAR (CON VALIDACIÓN DE DUPLICADOS)
        private void btnEditarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un estilista para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["ID"].Value);
            var estilistaAEditar = _estilistasSimulados.FirstOrDefault(x => x.Id == id);

            if (estilistaAEditar != null)
            {
                // Guardamos los datos viejos por si ocurre un duplicado
                string nombreViejo = estilistaAEditar.Nombre;
                string telefonoViejo = estilistaAEditar.Telefono;
                string especialidadVieja = estilistaAEditar.Especialidad;

                var ventanaRegistro = new FormEstilistaRegistro(estilistaAEditar);

                if (ventanaRegistro.ShowDialog() == DialogResult.OK)
                {
                    // 🔍 VALIDACIÓN: ¿Coincide con los datos de OTRO estilista?
                    bool duplicadoConOtro = _estilistasSimulados.Any(x =>
                        x.Id != id && (
                            x.Nombre.Trim().ToLower() == estilistaAEditar.Nombre.Trim().ToLower() ||
                            x.Telefono.Trim() == estilistaAEditar.Telefono.Trim()
                        ));

                    if (duplicadoConOtro)
                    {
                        MessageBox.Show(
                            "No se pueden guardar los cambios. Los datos coinciden con otro estilista ya registrado.",
                            "Error de Duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        // Restauramos los valores
                        estilistaAEditar.Nombre = nombreViejo;
                        estilistaAEditar.Telefono = telefonoViejo;
                        estilistaAEditar.Especialidad = especialidadVieja;
                        return;
                    }

                    ActualizarTablaEstilistas();
                    MessageBox.Show("Datos del estilista actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminarEstilista_Click(object sender, EventArgs e)
        {
            if (dgvEstilistas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvEstilistas.CurrentRow.Cells["ID"].Value);
            string nombre = dgvEstilistas.CurrentRow.Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Eliminar a {nombre}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var estilista = _estilistasSimulados.FirstOrDefault(x => x.Id == id);
                _estilistasSimulados.Remove(estilista);
                ActualizarTablaEstilistas();
            }
        }
    }

    public class EstilistaSimulado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
    }
}