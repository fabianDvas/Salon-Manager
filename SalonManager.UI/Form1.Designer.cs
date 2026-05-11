namespace SalonManager.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.IndianRed;
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(572, 46);
            label1.TabIndex = 0;
            label1.Text = "Administrador de Salones Y Barbería ";
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(12, 89);
            button1.Name = "button1";
            button1.Size = new Size(237, 40);
            button1.TabIndex = 1;
            button1.Text = "Citas";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.IndianRed;
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(12, 149);
            button2.Name = "button2";
            button2.Size = new Size(237, 40);
            button2.TabIndex = 2;
            button2.Text = "Clientes";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.IndianRed;
            button3.ForeColor = SystemColors.Window;
            button3.Location = new Point(12, 217);
            button3.Name = "button3";
            button3.Size = new Size(237, 40);
            button3.TabIndex = 3;
            button3.Text = "Estilistas";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Orange;
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(12, 298);
            button4.Name = "button4";
            button4.Size = new Size(237, 40);
            button4.TabIndex = 4;
            button4.Text = "Inventario";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Orange;
            button5.ForeColor = SystemColors.Window;
            button5.Location = new Point(12, 368);
            button5.Name = "button5";
            button5.Size = new Size(237, 40);
            button5.TabIndex = 5;
            button5.Text = "Comisiones";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(255, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 450);
            Controls.Add(pictureBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private PictureBox pictureBox1;
    }
}
