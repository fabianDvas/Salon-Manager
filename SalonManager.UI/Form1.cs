using Microsoft.Extensions.DependencyInjection;
using SalonManager.Datos;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCita cita = new FormCita();

            this.Hide();
            cita.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormClientes cliente = new FormClientes();

            this.Hide();
            cliente.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEstilistas estilista = new FormEstilistas();

            this.Hide();
            estilista.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
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
    }
}
