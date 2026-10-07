namespace JVMGYM.Windows
{
    partial class frmPrincipal
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
            btnClientes = new Button();
            btnMembresias = new Button();
            panelLateral = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelDerecho = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCerrarSesion = new Button();
            lblFecha = new Label();
            btnDuracionMembresia = new Button();
            panelLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelDerecho.SuspendLayout();
            SuspendLayout();
            // 
            // btnClientes
            // 
            btnClientes.AutoSize = true;
            btnClientes.BackColor = Color.MediumSeaGreen;
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(40, 182);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(170, 70);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "CLIENTES";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnMembresias
            // 
            btnMembresias.AutoSize = true;
            btnMembresias.BackColor = Color.MediumSeaGreen;
            btnMembresias.Cursor = Cursors.Hand;
            btnMembresias.FlatAppearance.BorderSize = 0;
            btnMembresias.FlatStyle = FlatStyle.Flat;
            btnMembresias.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMembresias.ForeColor = Color.White;
            btnMembresias.Location = new Point(40, 285);
            btnMembresias.Name = "btnMembresias";
            btnMembresias.Size = new Size(170, 70);
            btnMembresias.TabIndex = 2;
            btnMembresias.Text = "MEMBRESIAS";
            btnMembresias.UseVisualStyleBackColor = false;
            btnMembresias.Click += btnMembresias_Click;
            // 
            // panelLateral
            // 
            panelLateral.BackColor = Color.DarkGreen;
            panelLateral.Controls.Add(btnDuracionMembresia);
            panelLateral.Controls.Add(btnMembresias);
            panelLateral.Controls.Add(label1);
            panelLateral.Controls.Add(btnClientes);
            panelLateral.Controls.Add(pictureBox1);
            panelLateral.Dock = DockStyle.Left;
            panelLateral.Location = new Point(0, 0);
            panelLateral.Name = "panelLateral";
            panelLateral.Size = new Size(250, 493);
            panelLateral.TabIndex = 3;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 119);
            label1.Name = "label1";
            label1.Size = new Size(170, 40);
            label1.TabIndex = 1;
            label1.Text = "JVMGYM";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = Properties.Resources.logogym_removebg_preview;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelDerecho
            // 
            panelDerecho.BackColor = Color.Gainsboro;
            panelDerecho.Controls.Add(label4);
            panelDerecho.Controls.Add(label3);
            panelDerecho.Controls.Add(label2);
            panelDerecho.Controls.Add(btnCerrarSesion);
            panelDerecho.Controls.Add(lblFecha);
            panelDerecho.Dock = DockStyle.Fill;
            panelDerecho.Location = new Point(250, 0);
            panelDerecho.Name = "panelDerecho";
            panelDerecho.Size = new Size(827, 493);
            panelDerecho.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 269);
            label4.Name = "label4";
            label4.Size = new Size(258, 20);
            label4.TabIndex = 3;
            label4.Text = "Seleccione una opción para continuar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(302, 228);
            label3.Name = "label3";
            label3.Size = new Size(229, 20);
            label3.TabIndex = 3;
            label3.Text = "Sistema de Gestion de Gimnasios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 78);
            label2.Name = "label2";
            label2.Size = new Size(358, 38);
            label2.TabIndex = 2;
            label2.Text = "¡Bienvenido Nuevamente!";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.White;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Location = new Point(668, 28);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(126, 29);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = Color.Black;
            lblFecha.Location = new Point(546, 32);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(85, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "01/01/2026";
            // 
            // btnDuracionMembresia
            // 
            btnDuracionMembresia.AutoSize = true;
            btnDuracionMembresia.BackColor = Color.MediumSeaGreen;
            btnDuracionMembresia.Cursor = Cursors.Hand;
            btnDuracionMembresia.FlatAppearance.BorderSize = 0;
            btnDuracionMembresia.FlatStyle = FlatStyle.Flat;
            btnDuracionMembresia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDuracionMembresia.ForeColor = Color.White;
            btnDuracionMembresia.Location = new Point(40, 385);
            btnDuracionMembresia.Name = "btnDuracionMembresia";
            btnDuracionMembresia.Size = new Size(170, 70);
            btnDuracionMembresia.TabIndex = 2;
            btnDuracionMembresia.Text = "DURACION \r\nMEMBRESIAS";
            btnDuracionMembresia.UseVisualStyleBackColor = false;
            btnDuracionMembresia.Click += btnDuracionMembresia_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 493);
            Controls.Add(panelDerecho);
            Controls.Add(panelLateral);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            panelLateral.ResumeLayout(false);
            panelLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelDerecho.ResumeLayout(false);
            panelDerecho.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnClientes;
        private Button btnMembresias;
        private Panel panelLateral;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panelDerecho;
        private Label label2;
        private Button btnCerrarSesion;
        private Label lblFecha;
        private Label label4;
        private Label label3;
        private Button btnDuracionMembresia;
    }
}