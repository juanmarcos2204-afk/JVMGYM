namespace JVMGYM.Windows
{
    partial class frmMetodosDePagoAe
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
            txtNombre = new TextBox();
            btnOk = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 39);
            label1.Name = "label1";
            label1.Size = new Size(161, 31);
            label1.TabIndex = 0;
            label1.Text = "METODOS DE PAGO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 112);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre: ";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 109);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(212, 27);
            txtNombre.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.Checkmark;
            btnOk.Location = new Point(47, 304);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 92);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(317, 304);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 92);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmMetodosDePagoAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmMetodosDePagoAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMetodosDePagoAe";
            Load += frmMetodosDePagoAe_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombre;
        private Button btnOk;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
