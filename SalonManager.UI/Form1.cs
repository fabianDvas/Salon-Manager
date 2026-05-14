using Microsoft.Extensions.DependencyInjection;
using SalonManager.Datos;
using System;
using System.Windows.Forms;
using System.Linq; // Necesario para asegurar que las listas se procesen bien

namespace SalonManager.UI
{
    public partial class Form1 : Form
    {
        // 1. Instancias persistentes: se crean una sola vez para que los datos no se borren
        private FormClientes _frmClientes = new FormClientes();
        private FormEstilistas _frmEstilistas = new FormEstilistas();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 2. Obtenemos las listas
            var clientes = _frmClientes.ObtenerListaClientes();
            var estilistas = _frmEstilistas.ObtenerListaEstilistas();

            // 3. Pasamos las listas convirtiéndolas explícitamente a la interfaz
            // Esto resuelve el error CS1503 de la imagen image_d82868.png
            FormCita cita = new FormCita(
                clientes.Cast<IEntidadSencilla>(),
                estilistas.Cast<IEntidadSencilla>()
            );

            this.Hide();
            cita.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Abrimos la instancia de Clientes que ya tenemos guardada
            this.Hide();
            _frmClientes.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Abrimos la instancia de Estilistas que ya tenemos guardada
            this.Hide();
            _frmEstilistas.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Mantenemos tu conexión a la base de datos para el inventario
            var context = Program.ServiceProvider.GetRequiredService<SalonDbContext>();
            FormInventario inventario = new FormInventario(context);

            this.Hide();
            inventario.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormComisiones comisiones = new FormComisiones();
            this.Hide();
            comisiones.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}