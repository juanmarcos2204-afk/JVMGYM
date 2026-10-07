using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVMGYM.Windows
{
    public partial class frmDuracionMembresiasAe : Form
    {
        private DuracionMembresiaCreateDto _duracionMembresiaDto;
        public frmDuracionMembresiasAe()
        {
            InitializeComponent();
        }
        public DuracionMembresiaCreateDto GetDuracionMembresia()
        {
            return _duracionMembresiaDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EsValido())
            {
                _duracionMembresiaDto = new DuracionMembresiaCreateDto();
                _duracionMembresiaDto.Nombre = txtNombre.Text;

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
    }
}
