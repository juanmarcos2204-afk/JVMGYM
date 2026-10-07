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
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            tsbClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // tsbClientes
            // 
            tsbClientes.ImageScalingSize = new Size(20, 20);
            tsbClientes.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, toolStripSeparator1, tsbCerrar });
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
            splitContainer1.Size = new Size(1059, 375);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
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
            // frmDuracionMembresias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 450);
            Controls.Add(splitContainer1);
            Controls.Add(tsbClientes);
            MaximumSize = new Size(1077, 497);
            MinimumSize = new Size(1077, 497);
            Name = "frmDuracionMembresias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDuracionMembresias";
            Load += frmDuracionMembresias_Load;
            tsbClientes.ResumeLayout(false);
            tsbClientes.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
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
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
    }
}