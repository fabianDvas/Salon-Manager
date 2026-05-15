using SalonManager.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SalonManager.UI
{
    public partial class FormEstilistaRegistro : Form
    {
        // 1. Usamos la entidad real de la base de datos
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Estilista Estilista { get; private set; }

        // Constructor para un Estilista NUEVO
        public FormEstilistaRegistro()
        {
            InitializeComponent();
            // Creamos una instancia de la entidad real
            this.Estilista = new Estilista();
            this.Text = "Registrar Nuevo Estilista";
        }

        // Constructor para EDITAR (ahora recibe el Estilista real)
        public FormEstilistaRegistro(Estilista estilistaAEditar)
        {
            InitializeComponent();
            // Si nos pasan uno, lo usamos; si no, creamos uno nuevo por seguridad
            this.Estilista = estilistaAEditar ?? new Estilista();
            this.Text = "Editar Datos del Estilista";
        }

        private void FormEstilistaRegistro_Load(object sender, EventArgs e)
        {
            // Cargamos los datos en los TXT si estamos editando
            if (this.Estilista != null && !string.IsNullOrEmpty(this.Estilista.Nombre))
            {
                txtNombre.Text = this.Estilista.Nombre;
                txtTelefono.Text = this.Estilista.Telefono;
                txtEspecialidad.Text = this.Estilista.Especialidad;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, escribe el nombre del estilista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos los datos de los cuadros de texto en el objeto real
            this.Estilista.Nombre = txtNombre.Text;
            this.Estilista.Telefono = txtTelefono.Text;
            this.Estilista.Especialidad = txtEspecialidad.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
