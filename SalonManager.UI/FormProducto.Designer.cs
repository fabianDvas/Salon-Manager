namespace SalonManager.UI
{
    partial class FormProducto
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
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            cmbCategoria = new ComboBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtStockActual = new TextBox();
            txtStockMinimo = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej: Shampoo Pantene";
            txtNombre.Size = new Size(360, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(20, 102);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(360, 23);
            cmbCategoria.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 140);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 4;
            label3.Text = "Precio de Compra (RD$)";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(20, 162);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(360, 23);
            txtPrecio.TabIndex = 5;
            txtPrecio.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 200);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 6;
            label4.Text = "Stock Actual";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 200);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 7;
            label5.Text = "Stock Mínimo";
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(20, 222);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(160, 23);
            txtStockActual.TabIndex = 8;
            txtStockActual.Text = "0";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(210, 222);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(160, 23);
            txtStockMinimo.TabIndex = 9;
            txtStockMinimo.Text = "5";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(50, 280);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(210, 280);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 38);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 341);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtStockMinimo);
            Controls.Add(txtStockActual);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(cmbCategoria);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormProducto";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Producto";
            Load += FormProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private ComboBox cmbCategoria;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private Label label5;
        private TextBox txtStockActual;
        private TextBox txtStockMinimo;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}