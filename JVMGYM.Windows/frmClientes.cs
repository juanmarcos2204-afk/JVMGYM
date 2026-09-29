using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVMGYM.Windows
{
    public partial class frmClientes : Form
    {
        private readonly ClientesServicio _clientesServicio;
        private BindingSource _bindingSource = new BindingSource();
        public frmClientes(ClientesServicio clientesServicio)
        {
            InitializeComponent();
            _clientesServicio = clientesServicio;
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var resultado = _clientesServicio.ObtenerTodos();
            MostrarDatosGrilla(resultado);
        }

        private void MostrarDatosGrilla(List<ClientesListDto> resultado)
        {
            _bindingSource.DataSource = resultado;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
