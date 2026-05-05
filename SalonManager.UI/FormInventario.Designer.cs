namespace SalonManager.UI
{
    partial class FormInventario
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
            lblAlerta = new Label();
            btnStockBajo = new Button();
            dgvProductos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lblAlerta
            // 
            lblAlerta.AutoSize = true;
            lblAlerta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlerta.Location = new Point(12, 15);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(87, 19);
            lblAlerta.TabIndex = 0;
            lblAlerta.Text = "Cargando...";
            // 
            // btnStockBajo
            // 
            btnStockBajo.BackColor = Color.Orange;
            btnStockBajo.FlatStyle = FlatStyle.Flat;
            btnStockBajo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStockBajo.ForeColor = Color.White;
            btnStockBajo.Location = new Point(580, 10);
            btnStockBajo.Name = "btnStockBajo";
            btnStockBajo.Size = new Size(140, 35);
            btnStockBajo.TabIndex = 1;
            btnStockBajo.Text = "Ver Stock Bajo";
            btnStockBajo.UseVisualStyleBackColor = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 55);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(710, 340);
            dgvProductos.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MediumSeaGreen;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(112, 411);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(120, 38);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.SteelBlue;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(305, 411);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(120, 38);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(491, 411);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(120, 38);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 461);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductos);
            Controls.Add(btnStockBajo);
            Controls.Add(lblAlerta);
            Name = "FormInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario";
            Load += FormInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlerta;
        private Button btnStockBajo;
        private DataGridView dgvProductos;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
    }
}