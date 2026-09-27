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
            splitter1 = new Splitter();
            label1 = new Label();
            btnClientes = new Button();
            splitContainer1 = new SplitContainer();
            lblFecha = new Label();
            btnCerrarSesion = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(198, 450);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(169, 67);
            label1.TabIndex = 1;
            label1.Text = "JVMGYM";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            btnClientes.AutoSize = true;
            btnClientes.Location = new Point(12, 134);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(169, 66);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(198, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblFecha);
            splitContainer1.Panel1.Controls.Add(btnCerrarSesion);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Size = new Size(602, 450);
            splitContainer1.SplitterDistance = 85;
            splitContainer1.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(359, 32);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(85, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "01/01/2026";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(464, 28);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(126, 29);
            btnCerrarSesion.TabIndex = 0;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(198, 182);
            label4.Name = "label4";
            label4.Size = new Size(258, 20);
            label4.TabIndex = 1;
            label4.Text = "Seleccione una opción para continuar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 143);
            label3.Name = "label3";
            label3.Size = new Size(229, 20);
            label3.TabIndex = 1;
            label3.Text = "Sistema de Gestión de Gimnasios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 36);
            label2.Name = "label2";
            label2.Size = new Size(176, 20);
            label2.TabIndex = 0;
            label2.Text = "¡Bienvenido nuevamente!";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(btnClientes);
            Controls.Add(label1);
            Controls.Add(splitter1);
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrincipal";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Splitter splitter1;
        private Label label1;
        private Button btnClientes;
        private SplitContainer splitContainer1;
        private Label lblFecha;
        private Button btnCerrarSesion;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}