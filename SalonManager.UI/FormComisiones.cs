using System;
using System.Drawing;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormComisiones : Form
    {
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button btnLimpiar;
        private Label lblResultado;
        private Label lblTotal;
        private DataGridView dataGridView1;

        private decimal totalAcumulado = 0;

        public FormComisiones()
        {
            InitializeComponent();
            ConstruirInterfaz();
        }

        private void ConstruirInterfaz()
        {
            this.Text = "Sistema de Comisiones";
            this.Size = new Size(750, 550);

            Label lblNombre = new Label();
            lblNombre.Text = "Nombre estilista:";
            lblNombre.Location = new Point(30, 30);
            lblNombre.AutoSize = true;
            this.Controls.Add(lblNombre);

            textBox1 = new TextBox();
            textBox1.Location = new Point(160, 27);
            textBox1.Width = 180;
            this.Controls.Add(textBox1);

            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio servicio:";
            lblPrecio.Location = new Point(30, 70);
            lblPrecio.AutoSize = true;
            this.Controls.Add(lblPrecio);

            textBox2 = new TextBox();
            textBox2.Location = new Point(160, 67);
            textBox2.Width = 180;
            this.Controls.Add(textBox2);

            button1 = new Button();
            button1.Text = "Calcular Comisión";
            button1.Location = new Point(160, 110);
            button1.Width = 150;
            button1.Click += button1_Click;
            this.Controls.Add(button1);

            btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(330, 110);
            btnLimpiar.Width = 100;
            btnLimpiar.Click += btnLimpiar_Click;
            this.Controls.Add(btnLimpiar);

            lblResultado = new Label();
            lblResultado.Text = "Comisión generada:";
            lblResultado.Location = new Point(30, 160);
            lblResultado.AutoSize = true;
            this.Controls.Add(lblResultado);

            lblTotal = new Label();
            lblTotal.Text = "Total acumulado: RD$ 0";
            lblTotal.Location = new Point(30, 190);
            lblTotal.AutoSize = true;
            this.Controls.Add(lblTotal);

            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(30, 230);
            dataGridView1.Size = new Size(650, 230);
            dataGridView1.Columns.Add("colEstilista", "Estilista");
            dataGridView1.Columns.Add("colServicio", "Servicio");
            dataGridView1.Columns.Add("colComision", "Comisión");
            this.Controls.Add(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Complete todos los campos.");
            }
            else
            {
                string estilista = textBox1.Text;
                decimal precio = Convert.ToDecimal(textBox2.Text);
                decimal comision = precio * 0.40m;

                totalAcumulado += comision;

                lblResultado.Text = "Comisión generada: RD$ " + comision;
                lblTotal.Text = "Total acumulado: RD$ " + totalAcumulado;

                dataGridView1.Rows.Add(estilista, precio, comision);

                MessageBox.Show("El estilista " + estilista + " ganó RD$ " + comision);

                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            lblResultado.Text = "Comisión generada:";
            lblTotal.Text = "Total acumulado: RD$ 0";

            totalAcumulado = 0;
            dataGridView1.Rows.Clear();
        }
    }
}