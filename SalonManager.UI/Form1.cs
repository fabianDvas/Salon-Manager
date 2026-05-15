using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalonManager.Datos;
using System;
using System.Linq; // Necesario para asegurar que las listas se procesen bien
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class Form1 : Form
    {
        // 1. Instancias persistentes: se crean una sola vez para que los datos no se borren
        private FormClientes _frmClientes = new FormClientes(Program.ServiceProvider.GetRequiredService<SalonDbContext>());
        private FormEstilistas _frmEstilistas = new FormEstilistas(Program.ServiceProvider.GetRequiredService<SalonDbContext>());

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = Program.ServiceProvider.GetRequiredService<SalonDbContext>();
            FormCita cita = new FormCita(context);
            this.Hide();
            cita.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos la conexión oficial (la misma que usa el Inventario)
            var context = Program.ServiceProvider.GetRequiredService<SalonDbContext>();

            // 2. Creamos el formulario pasándole la base de datos
            // Ya no usamos _frmClientes, creamos uno nuevo para que cargue datos frescos
            var frm = new FormClientes(context);

            this.Hide();
            frm.ShowDialog();
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