using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVMGYM.Windows
{
    public partial class frmMetodosDePagoAe : Form
    {
        private MetodosDePagoEditDto? _metodoEditDto;
        public frmMetodosDePagoAe()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmMetodosDePagoAe_Load(object sender, EventArgs e)
        {
            if (_metodoEditDto is null)
            {
                // Nuevo ingreso
            }
            else
            {
                txtNombre.Text = _metodoEditDto.Nombre;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EsValido())
            {
                if (_metodoEditDto is null)
                {
                    _metodoEditDto = new MetodosDePagoEditDto();
                }
                _metodoEditDto.Nombre = txtNombre.Text;

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
            return esValido;
        }

        public MetodosDePagoEditDto GetMetodo()
        {
            return _metodoEditDto!;
        }

        public void SetMetodo(MetodosDePagoEditDto metodoEditDto)
        {
            _metodoEditDto = metodoEditDto;
        }
    }
}
