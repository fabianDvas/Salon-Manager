namespace SalonManager.UI
{
    partial class FormClienteRegistro
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
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(121, 300);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 45);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(383, 300);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 45);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 84);
            label1.Name = "label1";
            label1.Size = new Size(169, 25);
            label1.TabIndex = 2;
            label1.Text = "Nombre del Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 141);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 3;
            label2.Text = "Teléfono:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(296, 78);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(199, 31);
            txtNombre.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(296, 138);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(199, 31);
            txtTelefono.TabIndex = 5;
            // 
            // FormClienteRegistro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Name = "FormClienteRegistro";
            Text = "FormClienteRegistro";
            Load += FormClienteRegistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private TextBox txtTelefono;
    }
}