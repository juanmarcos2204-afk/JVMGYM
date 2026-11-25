using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using JVMGYM.Servicio.Dtos.Pagos;
using JVMGYM.Servicio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JVMGYM.Windows
{
    public partial class frmPagosAe : Form
    {
        private readonly IMetodoDePagoServicio _metodoDePagoServicio;
        private readonly IClientesServicio _clientesServicio;
        private PagoEditDto? _pagoEditDto;
        public frmPagosAe(IMetodoDePagoServicio metodoDePagoServicio, IClientesServicio clientesServicio)
        {
            InitializeComponent();
            _metodoDePagoServicio = metodoDePagoServicio;
            _clientesServicio = clientesServicio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmPagosAe_Load(object sender, EventArgs e)
        {
            CargarDatosCombo();
            if (_pagoEditDto is null)
            {
                dtpFecha.Enabled = false;
                dtpFecha.Value = DateTime.Now;
            }
            else
            {
                cboCliente.SelectedValue = _pagoEditDto.IdCliente;
                cboMetodoPago.SelectedValue = _pagoEditDto.IdMetodoPago;
                dtpFecha.Value = new DateTime(_pagoEditDto.Fecha.Year, _pagoEditDto.Fecha.Month, _pagoEditDto.Fecha.Day);
            }
        }

        private void CargarDatosCombo()
        {
            List<MetodoDePagoListDto> listaMetodosDePago = _metodoDePagoServicio.ObtenerDatosCombo();
            cboMetodoPago.DataSource = listaMetodosDePago;
            cboMetodoPago.DisplayMember = "Nombre";
            cboMetodoPago.ValueMember = "IdMetodoPago";
            cboMetodoPago.SelectedIndex = 0;

            List<ClientesListDto> listaClientes = _clientesServicio.ObtenerDatosCombo();
            cboCliente.DataSource = listaClientes;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "IdCliente";
            cboCliente.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EsValido())
            {
                if (_pagoEditDto is null)
                {
                    _pagoEditDto = new PagoEditDto();
                }
                _pagoEditDto.IdCliente = (int)cboCliente.SelectedValue!;
                _pagoEditDto.IdMetodoPago = (int)cboMetodoPago.SelectedValue!;
                _pagoEditDto.Fecha = DateOnly.FromDateTime(dtpFecha.Value.Date);

                DialogResult = DialogResult.OK;
            }
        }

        private bool EsValido()
        {
            bool esValido = true;
            errorProvider1.Clear();
            if (cboCliente.SelectedValue is null || (int)cboCliente.SelectedValue <= 0)
            {
                esValido = false;
                errorProvider1.SetError(cboCliente, "Seleccione un cliente válido");
            }
            if (cboMetodoPago.SelectedValue is null || (int)cboMetodoPago.SelectedValue <= 0)
            {
                esValido = false;
                errorProvider1.SetError(cboMetodoPago, "Seleccione un método de pago válido");
            }
            return esValido;
        }

        public PagoEditDto GetPago()
        {
            return _pagoEditDto!;
        }

        public void SetPago(PagoEditDto pagoEditDto)
        {
            _pagoEditDto = pagoEditDto;
        }
    }
}
