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
        public EstilistaSimulado Estilista { get; private set; }

        // Constructor para un Estilista NUEVO
        public FormEstilistaRegistro()
        {
            InitializeComponent();
            Estilista = new EstilistaSimulado();
            this.Text = "Registrar Nuevo Estilista";
        }

        // Constructor para EDITAR un estilista existente
        public FormEstilistaRegistro(EstilistaSimulado estilistaAEditar)
        {
            InitializeComponent();
            Estilista = estilistaAEditar;
            this.Text = "Editar Datos del Estilista";
        }

        private void FormEstilistaRegistro_Load(object sender, EventArgs e)
        {
            // Si tiene datos (estamos editando), los cargamos en las cajas de texto
            if (!string.IsNullOrEmpty(Estilista.Nombre))
            {
                txtNombre.Text = Estilista.Nombre;
                txtTelefono.Text = Estilista.Telefono;
                txtEspecialidad.Text = Estilista.Especialidad;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validamos que al menos pongan el nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, escribe el nombre del estilista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos los datos en el objeto
            Estilista.Nombre = txtNombre.Text;
            Estilista.Telefono = txtTelefono.Text;
            Estilista.Especialidad = txtEspecialidad.Text;

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
