namespace JVMGYM.Windows
{
    partial class frmPagos
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
            tsbPagos = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colMetodoPago = new DataGridViewTextBoxColumn();
            lblCantidad = new Label();
            label1 = new Label();
            tsbPagos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // tsbPagos
            // 
            tsbPagos.ImageScalingSize = new Size(20, 20);
            tsbPagos.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbBorrar, toolStripSeparator1, tsbCerrar });
            tsbPagos.Location = new Point(0, 0);
            tsbPagos.Name = "tsbPagos";
            tsbPagos.Size = new Size(1059, 75);
            tsbPagos.TabIndex = 0;
            tsbPagos.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = Properties.Resources.Plus;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(56, 72);
            tsbNuevo.Text = "&Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = Properties.Resources.Edit_Pencil;
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(52, 72);
            tsbEditar.Text = "&Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = Properties.Resources.Trash;
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(54, 72);
            tsbBorrar.Text = "&Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 75);
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = Properties.Resources.Cancel;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(53, 72);
            tsbCerrar.Text = "&Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 75);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblCantidad);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1059, 375);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colFecha, colCliente, colMetodoPago });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1059, 299);
            dgvDatos.TabIndex = 0;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colId.DataPropertyName = "IdPago";
            colId.HeaderText = "IdPago";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 125;
            // 
            // colFecha
            // 
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFecha.DataPropertyName = "Fecha";
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 6;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colMetodoPago
            // 
            colMetodoPago.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMetodoPago.DataPropertyName = "MetodoPago";
            colMetodoPago.HeaderText = "Método de Pago";
            colMetodoPago.MinimumWidth = 6;
            colMetodoPago.Name = "colMetodoPago";
            colMetodoPago.ReadOnly = true;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(158, 21);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(17, 20);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 21);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 0;
            label1.Text = "Cantidad Pagos: ";
            // 
            // frmPagos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 450);
            Controls.Add(splitContainer1);
            Controls.Add(tsbPagos);
            MaximumSize = new Size(1077, 497);
            MinimumSize = new Size(1077, 497);
            Name = "frmPagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPagos";
            Load += frmPagos_Load;
            tsbPagos.ResumeLayout(false);
            tsbPagos.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip tsbPagos;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbBorrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Label lblCantidad;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colMetodoPago;
    }
}
