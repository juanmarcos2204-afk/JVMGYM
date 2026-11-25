using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Pagos;
using JVMGYM.Servicio.DTOs.Paginación;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;
using JVMGYM.Windows.Helpers;
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
        private EstadoNavegacion _estadoNavegacion = new(10);
        public frmPagos(IPagosServicio pagosServicio, IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _pagosServicio = pagosServicio;
            _scopeFactory = scopeFactory;

            dgvDatos.AutoGenerateColumns = false;
        }
        private void frmPagos_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var paginaSolicitada = _estadoNavegacion.PaginaActual;
            var resultado = _pagosServicio
                .ObtenerPagina(paginaSolicitada,
                _estadoNavegacion.CantidadPorPagina,
                _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
            _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            if (paginaSolicitada != _estadoNavegacion.PaginaActual)
            {
                resultado = _pagosServicio
                    .ObtenerPagina(_estadoNavegacion.PaginaActual,
                    _estadoNavegacion.CantidadPorPagina,
                    _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
                _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            }
            MostrarDatosEnGrilla(resultado);
        }

        private void MostrarDatosEnGrilla(ResultadoPaginacionDto<PagoListDto> resultado)
        {
            _bindingSource.DataSource = resultado.Items;
            dgvDatos.DataSource = _bindingSource;

            lblCantidad.Text = _estadoNavegacion.TextoRegistros();

            btnPrimero.Enabled = resultado.TieneRegistrosAnteriores;
            btnAnterior.Enabled = resultado.TieneRegistrosAnteriores;
            btnSiguiente.Enabled = resultado.TieneRegistrosSiguientes;
            btnUltimo.Enabled = resultado.TieneRegistrosSiguientes;
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.Inicializar();
            RecargarGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.IrPrimera();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.IrAnterior();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.IrSiguiente();
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.IrUltima();
            RecargarGrilla();
        }
    }
}
