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
            if (_clientoDto is null)
            {
                chkActivo.Enabled = false;
                chkActivo.Checked = true;
            }
            else
            {
                txtNombre.Text = _clientoDto.Nombre;
                txtApellido.Text = _clientoDto.Apellido;
                txtDNI.Text = _clientoDto.DNI;
                lblDNI.Enabled = false;
                txtDNI.Enabled = false;
                txtTelefono.Text = _clientoDto.Telefono;
                txtDomicilio.Text = _clientoDto.Domicilio;
                chkActivo.Checked = _clientoDto.Activo;
            }
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
                _clientoDto.Activo = chkActivo.Checked;

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
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtApellido, "El campo Apellido es obligatorio");
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtDNI, "El campo DNI es obligatorio");
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtTelefono, "El campo Telefono es obligatorio");
            }
            if (string.IsNullOrEmpty(txtDomicilio.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtDomicilio, "El campo Domicilio es obligatorio");
            }
            return esValido;
        }

        public ClienteEditDto GetCliente()
        {
            return _clientoDto;
        }

        public void SetTipo(ClienteEditDto clienteEditDto)
        {
            _clientoDto = clienteEditDto;
        }
    }
}
