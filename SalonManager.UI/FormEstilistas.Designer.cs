namespace SalonManager.UI
{
    partial class FormEstilistas
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
            dgvEstilistas = new DataGridView();
            label1 = new Label();
            txtBuscarEstilista = new TextBox();
            btnAgregarEstilista = new Button();
            btnEditarEstilista = new Button();
            btnEliminarEstilista = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).BeginInit();
            SuspendLayout();
            // 
            // dgvEstilistas
            // 
            dgvEstilistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstilistas.Location = new Point(1, 112);
            dgvEstilistas.Margin = new Padding(2, 2, 2, 2);
            dgvEstilistas.Name = "dgvEstilistas";
            dgvEstilistas.RowHeadersWidth = 62;
            dgvEstilistas.Size = new Size(550, 268);
            dgvEstilistas.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 86);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar Estilista:";
            // 
            // txtBuscarEstilista
            // 
            txtBuscarEstilista.Location = new Point(104, 82);
            txtBuscarEstilista.Margin = new Padding(2, 2, 2, 2);
            txtBuscarEstilista.Name = "txtBuscarEstilista";
            txtBuscarEstilista.Size = new Size(210, 23);
            txtBuscarEstilista.TabIndex = 2;
            txtBuscarEstilista.TextChanged += txtBuscarEstilista_TextChanged;
            // 
            // btnAgregarEstilista
            // 
            btnAgregarEstilista.BackColor = Color.MediumSeaGreen;
            btnAgregarEstilista.ForeColor = SystemColors.ButtonHighlight;
            btnAgregarEstilista.Location = new Point(430, 9);
            btnAgregarEstilista.Margin = new Padding(2, 2, 2, 2);
            btnAgregarEstilista.Name = "btnAgregarEstilista";
            btnAgregarEstilista.Size = new Size(107, 31);
            btnAgregarEstilista.TabIndex = 3;
            btnAgregarEstilista.Text = "+ Agregar";
            btnAgregarEstilista.UseVisualStyleBackColor = false;
            btnAgregarEstilista.Click += btnAgregarEstilista_Click;
            // 
            // btnEditarEstilista
            // 
            btnEditarEstilista.BackColor = Color.SteelBlue;
            btnEditarEstilista.ForeColor = SystemColors.ButtonHighlight;
            btnEditarEstilista.Location = new Point(430, 43);
            btnEditarEstilista.Margin = new Padding(2, 2, 2, 2);
            btnEditarEstilista.Name = "btnEditarEstilista";
            btnEditarEstilista.Size = new Size(107, 29);
            btnEditarEstilista.TabIndex = 4;
            btnEditarEstilista.Text = "Editar";
            btnEditarEstilista.UseVisualStyleBackColor = false;
            btnEditarEstilista.Click += btnEditarEstilista_Click;
            // 
            // btnEliminarEstilista
            // 
            btnEliminarEstilista.BackColor = Color.IndianRed;
            btnEliminarEstilista.ForeColor = SystemColors.ButtonHighlight;
            btnEliminarEstilista.Location = new Point(430, 76);
            btnEliminarEstilista.Margin = new Padding(2, 2, 2, 2);
            btnEliminarEstilista.Name = "btnEliminarEstilista";
            btnEliminarEstilista.Size = new Size(107, 32);
            btnEliminarEstilista.TabIndex = 5;
            btnEliminarEstilista.Text = "- Eliminar";
            btnEliminarEstilista.UseVisualStyleBackColor = false;
            btnEliminarEstilista.Click += btnEliminarEstilista_Click;
            // 
            // FormEstilistas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 388);
            Controls.Add(btnEliminarEstilista);
            Controls.Add(btnEditarEstilista);
            Controls.Add(btnAgregarEstilista);
            Controls.Add(txtBuscarEstilista);
            Controls.Add(label1);
            Controls.Add(dgvEstilistas);
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormEstilistas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEstilistas";
            Load += FormEstilistas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEstilistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEstilistas;
        private Label label1;
        private TextBox txtBuscarEstilista;
        private Button btnAgregarEstilista;
        private Button btnEditarEstilista;
        private Button btnEliminarEstilista;
    }
}