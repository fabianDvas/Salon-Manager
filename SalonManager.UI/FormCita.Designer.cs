namespace SalonManager.UI
{
    partial class FormCita
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel2 = new Panel();
            label7 = new Label();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label9 = new Label();
            panel1 = new Panel();
            label8 = new Label();
            panel3 = new Panel();
            dtpFecha = new DateTimePicker();
            cmbEstilista = new ComboBox();
            cmbEstado = new ComboBox();
            cmbHora = new ComboBox();
            cmbCliente = new ComboBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            label10 = new Label();
            label11 = new Label();
            label5 = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(3, 361);
            panel2.Name = "panel2";
            panel2.Size = new Size(1288, 57);
            panel2.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.HotTrack;
            label7.Location = new Point(1087, 16);
            label7.Name = "label7";
            label7.Size = new Size(66, 25);
            label7.TabIndex = 9;
            label7.Text = "Estado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(60, 16);
            label1.Name = "label1";
            label1.Size = new Size(30, 25);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.HotTrack;
            label6.Location = new Point(887, 16);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 8;
            label6.Text = "Estilista";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(274, 16);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 4;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(476, 16);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 5;
            label3.Text = "Fecha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(674, 16);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 6;
            label4.Text = "Hora";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 419);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1292, 306);
            dataGridView1.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label9);
            flowLayoutPanel2.Location = new Point(6, 285);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1288, 70);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.HotTrack;
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(155, 30);
            label9.TabIndex = 0;
            label9.Text = "Lista de Citas";
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Location = new Point(6, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1285, 73);
            panel1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.HotTrack;
            label8.Location = new Point(22, 23);
            label8.Name = "label8";
            label8.Size = new Size(130, 30);
            label8.TabIndex = 0;
            label8.Text = "Nueva Cita";
            // 
            // panel3
            // 
            panel3.Controls.Add(dtpFecha);
            panel3.Controls.Add(cmbEstilista);
            panel3.Controls.Add(cmbEstado);
            panel3.Controls.Add(cmbHora);
            panel3.Controls.Add(cmbCliente);
            panel3.Controls.Add(btnEliminar);
            panel3.Controls.Add(btnEditar);
            panel3.Controls.Add(btnGuardar);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Location = new Point(6, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(1285, 198);
            panel3.TabIndex = 17;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(93, 62);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(182, 31);
            dtpFecha.TabIndex = 25;
            // 
            // cmbEstilista
            // 
            cmbEstilista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstilista.FormattingEnabled = true;
            cmbEstilista.Location = new Point(437, 56);
            cmbEstilista.Name = "cmbEstilista";
            cmbEstilista.Size = new Size(251, 33);
            cmbEstilista.TabIndex = 24;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(824, 3);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(170, 33);
            cmbEstado.TabIndex = 22;
            // 
            // cmbHora
            // 
            cmbHora.FormattingEnabled = true;
            cmbHora.Location = new Point(437, 3);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(251, 33);
            cmbHora.TabIndex = 21;
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(93, 0);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(182, 33);
            cmbCliente.TabIndex = 20;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.Beige;
            btnEliminar.Location = new Point(344, 130);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.MediumSeaGreen;
            btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = Color.Beige;
            btnEditar.Location = new Point(199, 130);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 34);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Beige;
            btnGuardar.Location = new Point(40, 130);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(740, 6);
            label14.Name = "label14";
            label14.Size = new Size(78, 25);
            label14.TabIndex = 16;
            label14.Text = "Estado:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(355, 8);
            label12.Name = "label12";
            label12.Size = new Size(61, 25);
            label12.TabIndex = 14;
            label12.Text = "Hora:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(341, 59);
            label13.Name = "label13";
            label13.Size = new Size(90, 25);
            label13.TabIndex = 15;
            label13.Text = "Estilista:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(7, 0);
            label10.Name = "label10";
            label10.Size = new Size(80, 25);
            label10.TabIndex = 12;
            label10.Text = "Cliente:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(19, 62);
            label11.Name = "label11";
            label11.Size = new Size(68, 25);
            label11.TabIndex = 13;
            label11.Text = "Fecha:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1081, 232);
            label5.Name = "label5";
            label5.Size = new Size(0, 25);
            label5.TabIndex = 7;
            // 
            // FormCita
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1294, 724);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(panel2);
            Name = "FormCita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCita";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dataGridView1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label9;
        private Panel panel1;
        private Label label8;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Panel panel3;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private ComboBox cmbEstado;
        private ComboBox cmbHora;
        private ComboBox cmbCliente;
        private ComboBox cmbEstilista;
        private DateTimePicker dtpFecha;
    }
}
