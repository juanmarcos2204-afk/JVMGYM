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
    public partial class frmClientesAe : Form
    {
        private ClienteEditDto _clientoDto;
        public frmClientesAe()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmClientesAe_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EsValido())
            {
                if (_clientoDto is null)
                {
                    _clientoDto = new ClienteEditDto();
                }
                _clientoDto.Nombre = txtNombre.Text;
                _clientoDto.Apellido = txtApellido.Text;
                _clientoDto.DNI = txtDNI.Text;
                _clientoDto.Telefono = txtTelefono.Text;
                _clientoDto.Domicilio = txtDomicilio.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool EsValido()
        {
            bool esValido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtNombre, "El campo Nombre es obligatorio");
            }
        }

        public ClienteEditDto GetCliente()
        {
            return _clientoDto;
        }
    }
}
