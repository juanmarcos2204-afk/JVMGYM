namespace JVMGYM.Windows
{
    partial class frmClientesAe
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblDNI = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDNI = new TextBox();
            txtTelefono = new TextBox();
            txtDomicilio = new TextBox();
            btnCancelar = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            lblActivo = new Label();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(49, 37);
            label1.Name = "label1";
            label1.Size = new Size(334, 28);
            label1.TabIndex = 0;
            label1.Text = "INGRESO DE DATOS PERSONALES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 85);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 138);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Apellido: ";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(49, 197);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(42, 20);
            lblDNI.TabIndex = 3;
            lblDNI.Text = "DNI: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 263);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 4;
            label5.Text = "Teléfono: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 331);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 5;
            label6.Text = "Domicilio: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(126, 82);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(128, 135);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(201, 27);
            txtApellido.TabIndex = 1;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(97, 194);
            txtDNI.MaxLength = 10;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(125, 27);
            txtDNI.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(129, 260);
            txtTelefono.MaxLength = 30;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(152, 27);
            txtTelefono.TabIndex = 3;
            // 
            // txtDomicilio
            // 
            txtDomicilio.BackColor = SystemColors.Menu;
            txtDomicilio.Location = new Point(136, 328);
            txtDomicilio.MaxLength = 30;
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(233, 27);
            txtDomicilio.TabIndex = 4;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(360, 498);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 92);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.Checkmark;
            btnOk.Location = new Point(49, 498);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 92);
            btnOk.TabIndex = 5;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(54, 393);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(0, 20);
            lblActivo.TabIndex = 7;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(49, 393);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(80, 24);
            chkActivo.TabIndex = 8;
            chkActivo.Text = "Activo: ";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // frmClientesAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(506, 621);
            Controls.Add(chkActivo);
            Controls.Add(lblActivo);
            Controls.Add(btnOk);
            Controls.Add(btnCancelar);
            Controls.Add(txtDomicilio);
            Controls.Add(txtTelefono);
            Controls.Add(txtDNI);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblDNI);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmClientesAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmClientesAe";
            Load += frmClientesAe_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblDNI;
        private Label label5;
        private Label label6;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDNI;
        private TextBox txtTelefono;
        private TextBox txtDomicilio;
        private Button btnCancelar;
        private Button btnOk;
        private ErrorProvider errorProvider1;
        private CheckBox chkActivo;
        private Label lblActivo;
    }
}