using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Servicio;
using JVMGYM.Servicio.Interfaces;
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
        private readonly IClientesServicio _clientesServicio;
        private readonly IMembresiaServicio _membresiaServicio;
        public frmPrincipal(IClientesServicio clientesServicio,
            IMembresiaServicio membresiaServicio)
        {
            InitializeComponent();
            _clientesServicio = clientesServicio;
            _membresiaServicio = membresiaServicio;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmClientes(_clientesServicio) { Text = "Listado de Clientes" })
            {
                frm.ShowDialog();
            }
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMembresias(_membresiaServicio) { Text = "Listado de Membresias" })
            {
                frm.ShowDialog();
            }
        }
    }
}
