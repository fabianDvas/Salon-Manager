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
            cmbEstado = new ComboBox();
            cmbEstilista = new ComboBox();
            cmbCliente = new ComboBox();
            dtpFecha = new DateTimePicker();
            checkedListBox1 = new CheckedListBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(110, 155);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(222, 33);
            cmbEstado.TabIndex = 1;
            // 
            // cmbEstilista
            // 
            cmbEstilista.FormattingEnabled = true;
            cmbEstilista.Location = new Point(110, 82);
            cmbEstilista.Name = "cmbEstilista";
            cmbEstilista.Size = new Size(222, 33);
            cmbEstilista.TabIndex = 2;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(110, 8);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(222, 33);
            cmbCliente.TabIndex = 3;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(403, 416);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(330, 31);
            dtpFecha.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(416, 43);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(338, 144);
            checkedListBox1.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            btnGuardar.Location = new Point(100, 91);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 34);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar Cita";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.SteelBlue;
            btnLimpiar.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            btnLimpiar.Location = new Point(66, 212);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(234, 34);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Quite sus selecciones aqui";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            btnCancelar.Location = new Point(117, 329);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Orange;
            label1.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(80, 28);
            label1.TabIndex = 5;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Orange;
            label2.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label2.Location = new Point(6, 82);
            label2.Name = "label2";
            label2.Size = new Size(88, 28);
            label2.TabIndex = 6;
            label2.Text = "Estilista";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Orange;
            label3.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label3.Location = new Point(10, 157);
            label3.Name = "label3";
            label3.Size = new Size(78, 28);
            label3.TabIndex = 4;
            label3.Text = "Estado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaption;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.Location = new Point(100, 11);
            label4.Name = "label4";
            label4.Size = new Size(188, 30);
            label4.TabIndex = 1;
            label4.Text = "Registro de Citas";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaption;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.Location = new Point(457, -2);
            label5.Name = "label5";
            label5.Size = new Size(254, 30);
            label5.TabIndex = 1;
            label5.Text = "Seleccione los Servicios";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Orange;
            label6.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold);
            label6.Location = new Point(18, 418);
            label6.Name = "label6";
            label6.Size = new Size(371, 28);
            label6.TabIndex = 0;
            label6.Text = "Selecione la hora de su cita aqui --->";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Sin_título;
            pictureBox1.Location = new Point(811, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(362, 412);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlDarkDark;
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Controls.Add(cmbEstilista);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(416, 210);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 200);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnCancelar);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(392, 460);
            panel1.TabIndex = 14;
            // 
            // FormCita
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 450);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(checkedListBox1);
            Controls.Add(dtpFecha);
            Name = "FormCita";
            Text = "FormCita";
            Load += FormCita_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbEstado;
        private ComboBox cmbEstilista;
        private ComboBox cmbCliente;
        private DateTimePicker dtpFecha;
        private CheckedListBox checkedListBox1;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnCancelar;
        private PictureBox pictureBox1;

        // Declaraciones definitivas con ruta completa
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}