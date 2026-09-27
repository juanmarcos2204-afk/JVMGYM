using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVMGYM.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly ClientesServicio _clientesServicio;
        public frmPrincipal(ClientesServicio clientesServicio)
        {
            InitializeComponent();
            _clientesServicio = clientesServicio;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmClientes(_clientesServicio) { Text = "Listado de Clientes"})
            {
                frm.ShowDialog();
            }
        }
    }
}
