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
            lblAlerta.Location = new Point(17, 25);
            lblAlerta.Margin = new Padding(4, 0, 4, 0);
            lblAlerta.Name = "lblAlerta";
            lblAlerta.Size = new Size(117, 28);
            lblAlerta.TabIndex = 0;
            lblAlerta.Text = "Cargando...";
            // 
            // btnStockBajo
            // 
            btnStockBajo.BackColor = Color.Orange;
            btnStockBajo.FlatStyle = FlatStyle.Flat;
            btnStockBajo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStockBajo.ForeColor = Color.White;
            btnStockBajo.Location = new Point(829, 17);
            btnStockBajo.Margin = new Padding(4, 5, 4, 5);
            btnStockBajo.Name = "btnStockBajo";
            btnStockBajo.Size = new Size(200, 58);
            btnStockBajo.TabIndex = 1;
            btnStockBajo.Text = "Ver Stock Bajo";
            btnStockBajo.UseVisualStyleBackColor = false;
            btnStockBajo.Click += btnStockBajo_Click_1;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(17, 92);
            dgvProductos.Margin = new Padding(4, 5, 4, 5);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1014, 567);
            dgvProductos.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MediumSeaGreen;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(160, 685);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(171, 63);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.SteelBlue;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(436, 685);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(171, 63);
            btnEditar.TabIndex = 4;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(701, 685);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(171, 63);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 768);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvProductos);
            Controls.Add(btnStockBajo);
            Controls.Add(lblAlerta);
            Margin = new Padding(4, 5, 4, 5);
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