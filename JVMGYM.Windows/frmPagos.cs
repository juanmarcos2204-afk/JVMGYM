using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Pagos;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;
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
    public partial class frmPagos : Form
    {
        private readonly IPagosServicio _pagosServicio;
        private readonly IServiceScopeFactory _scopeFactory;
        private BindingSource _bindingSource = new BindingSource();
        public frmPagos(IPagosServicio pagosServicio, IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _pagosServicio = pagosServicio;
            _scopeFactory = scopeFactory;
        }
        private void frmPagos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var resultado = _pagosServicio.ObtenerTodos();
            MostrarDatosGrilla(resultado);
        }

        private void MostrarDatosGrilla(List<PagoListDto> resultado)
        {
            _bindingSource.DataSource = resultado;
            dgvDatos.DataSource = _bindingSource;
            lblCantidad.Text = resultado.Count.ToString();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmPagosAe>())
                {
                    frm.Text = "Ingreso de Pago";
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    PagoEditDto pagoEditDto = frm.GetPago();
                    PagoCreateDto pagoCreateDto = pagoEditDto.ToCreateDto();
                    try
                    {
                        _pagosServicio.Agregar(pagoCreateDto);
                        MessageBox.Show("Pago Añadido",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RecargarGrilla();

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message,
                            "ERROR",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            PagoListDto pagoListDto = (PagoListDto)_bindingSource.Current!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el pago del cliente {pagoListDto.Cliente}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _pagosServicio.Eliminar(pagoListDto.IdPago);
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            PagoListDto pagoListDto = (PagoListDto)_bindingSource.Current!;
            PagoEditDto pagoEditDto = _pagosServicio.ObtenerParaEditar(pagoListDto.IdPago);
            if (pagoEditDto is null)
            {
                MessageBox.Show("Pago no encontrado",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmPagosAe>())
                {
                    frm.Text = "Editar Pago";
                    frm.SetPago(pagoEditDto);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    pagoEditDto = frm.GetPago();
                    if (pagoEditDto is null) return;
                    try
                    {
                        _pagosServicio.Editar(pagoEditDto);
                        RecargarGrilla();
                        MessageBox.Show("Pago editado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
