namespace JVMGYM.Windows
{
    partial class frmMembresiasAe
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
            cboDuracion = new ComboBox();
            label4 = new Label();
            txtTipo = new TextBox();
            nudPrecio = new NumericUpDown();
            btnOk = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
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
            label1.Text = "MEMBRESIAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 112);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Tipo: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 173);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Precio: ";
            // 
            // cboDuracion
            // 
            cboDuracion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDuracion.FormattingEnabled = true;
            cboDuracion.Location = new Point(260, 224);
            cboDuracion.Name = "cboDuracion";
            cboDuracion.Size = new Size(151, 28);
            cboDuracion.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 227);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 4;
            label4.Text = "Duración de la Membresia: ";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(121, 109);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(212, 27);
            txtTipo.TabIndex = 0;
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(121, 171);
            nudPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(150, 27);
            nudPrecio.TabIndex = 1;
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
            // frmMembresiasAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(nudPrecio);
            Controls.Add(txtTipo);
            Controls.Add(label4);
            Controls.Add(cboDuracion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmMembresiasAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMembresiasAe";
            Load += frmMembresiasAe_Load;
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboDuracion;
        private Label label4;
        private TextBox txtTipo;
        private NumericUpDown nudPrecio;
        private Button btnOk;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}