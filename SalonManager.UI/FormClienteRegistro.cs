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
    public partial class FormClienteRegistro : Form
    {
        // 1. Usamos 'Cliente' (singular) para que coincida con la base de datos
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cliente Cliente { get; set; }

        // Constructor para NUEVO cliente
        public FormClienteRegistro()
        {
            InitializeComponent();
            // Creamos un cliente vacío listo para llenar
            this.Cliente = new Cliente();
            this.Text = "Registrar Nuevo Cliente";
        }

        // Constructor para EDITAR (recibe el cliente real, no el simulado)
        public FormClienteRegistro(Cliente clienteAEditar)
        {
            InitializeComponent();
            // Si mandamos un cliente de la DB, lo guardamos aquí
            this.Cliente = clienteAEditar ?? new Cliente();
            this.Text = "Editar Datos del Cliente";
        }

        private void FormClienteRegistro_Load(object sender, EventArgs e)
        {
            // Llenamos los campos si ya tenemos datos (Editar)
            if (this.Cliente != null && !string.IsNullOrEmpty(this.Cliente.Nombre))
            {
                txtNombre.Text = this.Cliente.Nombre;
                txtTelefono.Text = this.Cliente.Telefono;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, escribe el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pasamos los textos al objeto que se guardará en la DB
            this.Cliente.Nombre = txtNombre.Text;
            this.Cliente.Telefono = txtTelefono.Text;

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