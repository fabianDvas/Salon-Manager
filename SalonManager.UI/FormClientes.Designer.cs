namespace SalonManager.UI
{
    partial class FormClientes
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
            dgvClientes = new DataGridView();
            label1 = new Label();
            txtBuscarCliente = new TextBox();
            btnAgregarCliente = new Button();
            btnEditarCliente = new Button();
            btnEliminarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(24, 100);
            dgvClientes.Margin = new Padding(2, 2, 2, 2);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 62;
            dgvClientes.Size = new Size(472, 327);
            dgvClientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 75);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar Cliente:";
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(116, 71);
            txtBuscarCliente.Margin = new Padding(2, 2, 2, 2);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(169, 23);
            txtBuscarCliente.TabIndex = 2;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.MediumSeaGreen;
            btnAgregarCliente.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarCliente.Location = new Point(57, 24);
            btnAgregarCliente.Margin = new Padding(2, 2, 2, 2);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(127, 28);
            btnAgregarCliente.TabIndex = 3;
            btnAgregarCliente.Text = "+ Agregar Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // btnEditarCliente
            // 
            btnEditarCliente.BackColor = Color.SteelBlue;
            btnEditarCliente.ForeColor = SystemColors.ButtonHighlight;
            btnEditarCliente.Location = new Point(189, 24);
            btnEditarCliente.Margin = new Padding(2, 2, 2, 2);
            btnEditarCliente.Name = "btnEditarCliente";
            btnEditarCliente.Size = new Size(127, 28);
            btnEditarCliente.TabIndex = 4;
            btnEditarCliente.Text = "Editar";
            btnEditarCliente.UseVisualStyleBackColor = false;
            
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.BackColor = Color.IndianRed;
            btnEliminarCliente.ForeColor = SystemColors.ButtonHighlight;
            btnEliminarCliente.Location = new Point(321, 24);
            btnEliminarCliente.Margin = new Padding(2, 2, 2, 2);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(127, 28);
            btnEliminarCliente.TabIndex = 5;
            btnEliminarCliente.Text = "- Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 434);
            Controls.Add(btnEliminarCliente);
            Controls.Add(btnEditarCliente);
            Controls.Add(btnAgregarCliente);
            Controls.Add(txtBuscarCliente);
            Controls.Add(label1);
            Controls.Add(dgvClientes);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormClientes";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Label label1;
        private TextBox txtBuscarCliente;
        private Button btnAgregarCliente;
        private Button btnEditarCliente;
        private Button btnEliminarCliente;
    }
}