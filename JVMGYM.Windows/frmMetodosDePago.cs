using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
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
    public partial class frmMetodosDePago : Form
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMetodoDePagoServicio _metodoDePagoServicio;
        private BindingSource _bindingSource = new BindingSource();
        private EstadoNavegacion _estadoNavegacion = new(10);
        public frmMetodosDePago(IMetodoDePagoServicio metodoDePagoServicio, IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _metodoDePagoServicio = metodoDePagoServicio;
            _scopeFactory = scopeFactory;

            dgvDatos.AutoGenerateColumns = false;
        }
        private void frmMetodosDePago_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var paginaSolicitada = _estadoNavegacion.PaginaActual;
            var resultado = _metodoDePagoServicio
                .ObtenerPagina(paginaSolicitada,
                _estadoNavegacion.CantidadPorPagina,
                _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
            _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            if (paginaSolicitada != _estadoNavegacion.PaginaActual)
            {
                resultado = _metodoDePagoServicio
                    .ObtenerPagina(_estadoNavegacion.PaginaActual,
                    _estadoNavegacion.CantidadPorPagina,
                    _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
                _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            }
            MostrarDatosEnGrilla(resultado);
        }

        private void MostrarDatosEnGrilla(ResultadoPaginacionDto<MetodoDePagoListDto> resultado)
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
                using (var frm = scope.ServiceProvider.GetRequiredService<frmMetodosDePagoAe>())
                {
                    frm.Text = "Ingreso de Método de Pago";
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    MetodosDePagoEditDto metodoEditDto = frm.GetMetodo();
                    MetodosDePagoCreateDto metodoCreateDto = metodoEditDto.ToCreateDto();
                    try
                    {
                        _metodoDePagoServicio.Agregar(metodoCreateDto);
                        MessageBox.Show("Método de pago Añadido",
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
            MetodoDePagoListDto metodoListDto = (MetodoDePagoListDto)_bindingSource.Current!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el método de pago {metodoListDto.Nombre}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _metodoDePagoServicio.Eliminar(metodoListDto.IdMetodoPago);
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
            MetodoDePagoListDto metodoListDto = (MetodoDePagoListDto)_bindingSource.Current!;
            MetodosDePagoEditDto metodoEditDto = _metodoDePagoServicio.ObtenerParaEditar(metodoListDto.IdMetodoPago);
            if (metodoEditDto is null)
            {
                MessageBox.Show("Método de pago no encontrado",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmMetodosDePagoAe>())
                {
                    frm.Text = "Editar Método de Pago";
                    frm.SetMetodo(metodoEditDto);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    metodoEditDto = frm.GetMetodo();
                    if (metodoEditDto is null) return;
                    try
                    {
                        _metodoDePagoServicio.Editar(metodoEditDto);
                        RecargarGrilla();
                        MessageBox.Show("Método de pago editado",
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
