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
        // Esta variable guardará el cliente que estamos creando o editando
        public ClienteSimulado Cliente { get; private set; }

        // Constructor para cuando es un cliente NUEVO
        public FormClienteRegistro()
        {
            InitializeComponent();
            Cliente = new ClienteSimulado();
            this.Text = "Registrar Nuevo Cliente";
        }

        // Constructor para cuando vamos a EDITAR (recibe el cliente seleccionado)
        public FormClienteRegistro(ClienteSimulado clienteAEditar)
        {
            InitializeComponent();
            Cliente = clienteAEditar;
            this.Text = "Editar Datos del Cliente";
        }

        // Se ejecuta al cargar la ventanita
        private void FormClienteRegistro_Load(object sender, EventArgs e)
        {
            // Si el cliente ya tiene nombre (porque estamos editando), lo ponemos en los cuadros
            if (!string.IsNullOrEmpty(Cliente.Nombre))
            {
                txtNombre.Text = Cliente.Nombre;
                txtTelefono.Text = Cliente.Telefono;
            }
        }

        // Botón GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación básica: Que no dejen el nombre vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, escribe el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardamos lo que escribió la recepcionista en el objeto Cliente
            Cliente.Nombre = txtNombre.Text;
            Cliente.Telefono = txtTelefono.Text;

            // Le avisamos al formulario principal que todo salió bien
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Botón CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}