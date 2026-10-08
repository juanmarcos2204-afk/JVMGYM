using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using JVMGYM.Servicio.Dtos.Membresias;
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
    public partial class frmMembresiasAe : Form
    {
        private readonly IDuracionMembresiaServicio _duracionMembresiaServicio;
        private MembresiaEditDto _membresiaEditDto;
        public frmMembresiasAe(IDuracionMembresiaServicio duracionMembresiaServicio)
        {
            InitializeComponent();
            _duracionMembresiaServicio = duracionMembresiaServicio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmMembresiasAe_Load(object sender, EventArgs e)
        {
            CargarDatosCombo(cboDuracion);
            if (_membresiaEditDto is not null)
            {
                txtTipo.Text = _membresiaEditDto.Tipo;
                nudPrecio.Value = _membresiaEditDto.Precio;
                cboDuracion.SelectedValue = _membresiaEditDto.IdDuracionMembresia;
            }
        }

        private void CargarDatosCombo(ComboBox cboDuracion)
        {
            List<DuracionMembresiaListDto> listaDuracionMembresias = _duracionMembresiaServicio.ObtenerDatosCombo();
            cboDuracion.DataSource = listaDuracionMembresias;
            cboDuracion.DisplayMember = "Nombre";
            cboDuracion.ValueMember = "IdDuracionMembresia";
            cboDuracion.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EsValido())
            {
                if (_membresiaEditDto is null)
                {
                    _membresiaEditDto = new MembresiaEditDto();
                }
                _membresiaEditDto.Tipo = txtTipo.Text;
                _membresiaEditDto.Precio = nudPrecio.Value;
                _membresiaEditDto.IdDuracionMembresia = (int)cboDuracion.SelectedValue!;

                DialogResult = DialogResult.OK;
            }
        }

        private bool EsValido()
        {
            bool esValido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipo.Text))
            {
                esValido = false;
                errorProvider1.SetError(txtTipo, "El campo tipo es obligatorio");
            }
            if (cboDuracion.SelectedIndex == 0)
            {
                esValido = false;
                errorProvider1.SetError(cboDuracion, "Seleccione una opción válida");
            }
            return esValido;
        }
        public MembresiaEditDto GetMembresia()
        {
            return _membresiaEditDto;
        }

        public void SetMembresia(MembresiaEditDto membresiaEditDto)
        {
            _membresiaEditDto = membresiaEditDto;
        }
    }
}
