using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Membresias;
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
    public partial class frmMembresias : Form
    {
        private readonly IMembresiaServicio _membresiaServicio;
        private readonly IDuracionMembresiaServicio _duracionMembresiaServicio;
        private readonly IServiceScopeFactory _scopeFactory;
        private BindingSource _bindingSource = new BindingSource();
        private EstadoNavegacion _estadoNavegacion = new(10);
        public frmMembresias(IMembresiaServicio membresiaServicio,
            IDuracionMembresiaServicio duracionMembresiaServicio,
            IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _membresiaServicio = membresiaServicio;
            _duracionMembresiaServicio = duracionMembresiaServicio;
            _scopeFactory = scopeFactory;

            dgvDatos.AutoGenerateColumns = false;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMembresias_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var paginaSolicitada = _estadoNavegacion.PaginaActual;
            var resultado = _membresiaServicio
                .ObtenerPagina(paginaSolicitada,
                _estadoNavegacion.CantidadPorPagina,
                _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
            _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            if (paginaSolicitada != _estadoNavegacion.PaginaActual)
            {
                resultado = _membresiaServicio
                    .ObtenerPagina(_estadoNavegacion.PaginaActual,
                    _estadoNavegacion.CantidadPorPagina,
                    _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
                _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            }
            MostrarDatosEnGrilla(resultado);
        }

        private void MostrarDatosEnGrilla(ResultadoPaginacionDto<MembresiaListDto> resultado)
        {
            _bindingSource.DataSource = resultado.Items;
            dgvDatos.DataSource = _bindingSource;

            lblCantidad.Text = _estadoNavegacion.TextoRegistros();

            btnPrimero.Enabled = resultado.TieneRegistrosAnteriores;
            btnAnterior.Enabled = resultado.TieneRegistrosAnteriores;
            btnSiguiente.Enabled = resultado.TieneRegistrosSiguientes;
            btnUltimo.Enabled = resultado.TieneRegistrosSiguientes;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmMembresiasAe>())
                {
                    frm.Text = "Ingreso de Membresia";
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    MembresiaEditDto membresiaEditDto = frm.GetMembresia();
                    MembresiaCreateDto membresiaCreateDto = membresiaEditDto.ToCreateDto();
                    try
                    {
                        _membresiaServicio.Agregar(membresiaCreateDto);
                        MessageBox.Show("Membresia Añadida",
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
            MembresiaListDto membresiaListDto = (MembresiaListDto)_bindingSource.Current!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar la membresia {membresiaListDto.Tipo}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _membresiaServicio.Eliminar(membresiaListDto.IdMembresia);
            RecargarGrilla();
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
            MembresiaListDto membresiaListDto = (MembresiaListDto)_bindingSource.Current!;
            MembresiaEditDto? membresiaEditDto = _membresiaServicio.ObtenerParaEditar(membresiaListDto.IdMembresia);
            if (membresiaEditDto is null)
            {
                MessageBox.Show("Membresia no encontrada",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmMembresiasAe>())
                {
                    frm.Text = "Editar Membresia";
                    frm.SetMembresia(membresiaEditDto!);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    membresiaEditDto = frm.GetMembresia();
                    if (membresiaEditDto is null) return;
                    try
                    {
                        _membresiaServicio.Editar(membresiaEditDto);
                        int editadoId = membresiaEditDto.IdMembresia;
                        RecargarGrilla();
                        var editadoMembresia = _bindingSource.List
                                .Cast<MembresiaListDto>()
                                .FirstOrDefault(m => m.IdMembresia == editadoId);
                        _bindingSource.Position = _bindingSource.IndexOf(editadoMembresia);
                        MessageBox.Show("Membresia editada",
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

