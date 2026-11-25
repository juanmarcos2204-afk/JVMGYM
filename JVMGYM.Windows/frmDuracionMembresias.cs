using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.DTOs.Paginación;
using JVMGYM.Servicio.Interfaces;
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
    public partial class frmDuracionMembresias : Form
    {

        private readonly IDuracionMembresiaServicio _duracionMembresiaServicio;
        private readonly IServiceScopeFactory _scopeFactory;
        private BindingSource _bindingSource = new BindingSource();
        private EstadoNavegacion _estadoNavegacion = new(10);
        public frmDuracionMembresias(IDuracionMembresiaServicio duracionMembresiaServicio, IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _duracionMembresiaServicio = duracionMembresiaServicio;
            _scopeFactory = scopeFactory;

            dgvDatos.AutoGenerateColumns = false;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmDuracionMembresias_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var paginaSolicitada = _estadoNavegacion.PaginaActual;
            var resultado = _duracionMembresiaServicio
                .ObtenerPagina(paginaSolicitada,
                _estadoNavegacion.CantidadPorPagina,
                _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
            _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            if (paginaSolicitada != _estadoNavegacion.PaginaActual)
            {
                resultado = _duracionMembresiaServicio
                    .ObtenerPagina(_estadoNavegacion.PaginaActual,
                    _estadoNavegacion.CantidadPorPagina,
                    _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
                _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            }
            MostrarDatosEnGrilla(resultado);
        }

        private void MostrarDatosEnGrilla(ResultadoPaginacionDto<DuracionMembresiaListDto> resultado)
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
                using (var frm = scope.ServiceProvider.GetRequiredService<frmDuracionMembresiasAe>())
                {
                    frm.Text = "Ingreso de Duración de Membresias";
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    DuracionMembresiaCreateDto duracionMembresiaCreateDto = frm.GetDuracionMembresia();
                    try
                    {
                        _duracionMembresiaServicio.Agregar(duracionMembresiaCreateDto);
                        MessageBox.Show("Duración Membresia Añadida",
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
            DuracionMembresiaListDto duracionMembresiaListDto = (DuracionMembresiaListDto)_bindingSource.Current!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar la duración {duracionMembresiaListDto.Nombre}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                _duracionMembresiaServicio.Eliminar(duracionMembresiaListDto.IdDuracionMembresia);
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
