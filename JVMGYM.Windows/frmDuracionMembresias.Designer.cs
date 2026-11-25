namespace JVMGYM.Windows
{
    partial class frmDuracionMembresias
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
            tsbClientes = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbActualizar = new ToolStripButton();
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            btnUltimo = new Button();
            lblCantidad = new Label();
            btnSiguiente = new Button();
            label1 = new Label();
            btnAnterior = new Button();
            btnPrimero = new Button();
            tsbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // tsbClientes
            // 
            tsbClientes.ImageScalingSize = new Size(20, 20);
            tsbClientes.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, toolStripSeparator1, tsbActualizar, tsbCerrar });
            tsbClientes.Location = new Point(0, 0);
            tsbClientes.Name = "tsbClientes";
            tsbClientes.Size = new Size(1059, 75);
            tsbClientes.TabIndex = 0;
            tsbClientes.Text = "toolStrip1";
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
            // tsbActualizar
            // 
            tsbActualizar.Image = Properties.Resources.Refresh;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(79, 72);
            tsbActualizar.Text = "&Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
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
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(lblCantidad);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Size = new Size(1059, 372);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.ColumnHeadersHeight = 28;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.RowTemplate.Height = 26;
            dgvDatos.ScrollBars = ScrollBars.Vertical;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1059, 288);
            dgvDatos.TabIndex = 0;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colId.DataPropertyName = "IdDuracionMembresia";
            colId.HeaderText = "IdDuracionMembresia";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Ultimo;
            btnUltimo.Location = new Point(610, 17);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(50, 45);
            btnUltimo.TabIndex = 4;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(198, 30);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(17, 20);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "0";
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Siguiente;
            btnSiguiente.Location = new Point(540, 17);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(50, 45);
            btnSiguiente.TabIndex = 3;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 30);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 0;
            label1.Text = "Cantidad Duraciones: ";
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.Anterior;
            btnAnterior.Location = new Point(470, 17);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(50, 45);
            btnAnterior.TabIndex = 2;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.Previous;
            btnPrimero.Location = new Point(400, 17);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(50, 45);
            btnPrimero.TabIndex = 1;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // frmDuracionMembresias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 447);
            Controls.Add(splitContainer1);
            Controls.Add(tsbClientes);
            MaximumSize = new Size(1077, 494);
            MinimumSize = new Size(1077, 494);
            Name = "frmDuracionMembresias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDuracionMembresias";
            Load += frmDuracionMembresias_Load;
            tsbClientes.ResumeLayout(false);
            tsbClientes.PerformLayout();
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

        private ToolStrip tsbClientes;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbActualizar;
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Label lblCantidad;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
    }
}
