namespace JVMGYM.Windows
{
    partial class frmPagosAe
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
            label4 = new Label();
            cboCliente = new ComboBox();
            cboMetodoPago = new ComboBox();
            dtpFecha = new DateTimePicker();
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
            label1.Text = "PAGOS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 100);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "Cliente: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 180);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 140);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 3;
            label4.Text = "Método de pago: ";
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(260, 97);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(151, 28);
            cboCliente.TabIndex = 2;
            // 
            // cboMetodoPago
            // 
            cboMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMetodoPago.FormattingEnabled = true;
            cboMetodoPago.Location = new Point(260, 137);
            cboMetodoPago.Name = "cboMetodoPago";
            cboMetodoPago.Size = new Size(151, 28);
            cboMetodoPago.TabIndex = 3;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(121, 177);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 28);
            dtpFecha.TabIndex = 4;
            dtpFecha.Value = new DateTime(2026, 1, 1);
            // 
            // btnOk
            // 
            btnOk.Image = Properties.Resources.Checkmark;
            btnOk.Location = new Point(47, 304);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 92);
            btnOk.TabIndex = 5;
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
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmPagosAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(dtpFecha);
            Controls.Add(cboMetodoPago);
            Controls.Add(cboCliente);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPagosAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPagosAe";
            Load += frmPagosAe_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cboCliente;
        private ComboBox cboMetodoPago;
        private DateTimePicker dtpFecha;
        private Button btnOk;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
