namespace SalonManager.UI
{
    partial class FormEstilistaRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancelar = new Button();
            btnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtEspecialidad = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.ForeColor = SystemColors.ButtonHighlight;
            btnCancelar.Location = new Point(418, 301);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 55);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.ForeColor = SystemColors.ButtonHighlight;
            btnGuardar.Location = new Point(95, 301);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 55);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 75);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 2;
            label1.Text = "Nombre del Estilista:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 139);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 3;
            label2.Text = "Teléfono:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(296, 69);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(246, 31);
            txtNombre.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(296, 133);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(246, 31);
            txtTelefono.TabIndex = 5;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(296, 201);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(246, 31);
            txtEspecialidad.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 207);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 7;
            label3.Text = "Especialidad:";
            // 
            // FormEstilistaRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "FormEstilistaRegistro";
            Text = "FormEstilistaRegistro";
            Load += FormEstilistaRegistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtEspecialidad;
        private Label label3;
    }
}