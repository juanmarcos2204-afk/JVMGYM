using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
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
    public partial class frmClientes : Form
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IClientesServicio _clientesServicio;
        private BindingSource _bindingSource = new BindingSource();
        private EstadoNavegacion _estadoNavegacion = new(10);
        public frmClientes(IServiceScopeFactory scopeFactory, IClientesServicio clientesServicio)
        {
            InitializeComponent();
            _scopeFactory = scopeFactory;
            _clientesServicio = clientesServicio;

            dgvDatos.AutoGenerateColumns = false;
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var paginaSolicitada = _estadoNavegacion.PaginaActual;
            var resultado = _clientesServicio
                .ObtenerPagina(paginaSolicitada,
                _estadoNavegacion.CantidadPorPagina,
                _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
            _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            if (paginaSolicitada != _estadoNavegacion.PaginaActual)
            {
                resultado = _clientesServicio
                    .ObtenerPagina(_estadoNavegacion.PaginaActual,
                    _estadoNavegacion.CantidadPorPagina,
                    _estadoNavegacion.FiltroActivo, _estadoNavegacion.TextoBuscar);
                _estadoNavegacion.Actualizar(resultado.TotalRegistros);
            }
            MostrarDatosEnGrilla(resultado);
        }

        private void MostrarDatosEnGrilla(ResultadoPaginacionDto<ClientesListDto> resultado)
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
                using (var frm = scope.ServiceProvider.GetRequiredService<frmClientesAe>())
                {
                    frm.Text = "Ingreso de Cliente";
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    ClienteEditDto clienteEditDto = frm.GetCliente();
                    ClienteCreateDto clienteCreateDto = clienteEditDto.ToCreateDto();
                    try
                    {
                        _clientesServicio.Agregar(clienteCreateDto);
                        MessageBox.Show("Cliente Añadido",
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
            ClientesListDto clienteListDto = (ClientesListDto)_bindingSource.Current!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el cliente {clienteListDto.Nombre}?",
                "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _clientesServicio.Eliminar(clienteListDto.IdCliente);
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
            ClientesListDto clienteListDto = (ClientesListDto)_bindingSource.Current!;
            ClienteEditDto? clienteEditDto = _clientesServicio.ObtenerParaEditar(clienteListDto.IdCliente);
            if (clienteEditDto is null)
            {
                MessageBox.Show("Cliente no encontrado",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmClientesAe>())
                {
                    frm.Text = "Editar Cliente";
                    frm.SetTipo(clienteEditDto!);
                    DialogResult dr = frm.ShowDialog();
                    if (dr == DialogResult.Cancel) return;
                    clienteEditDto = frm.GetCliente();
                    if (clienteEditDto is null) return;
                    try
                    {
                        _clientesServicio.Editar(clienteEditDto);
                        int editadoId = clienteEditDto.IdCliente;
                        RecargarGrilla();
                        var editadoCliente = _bindingSource.List
                                .Cast<ClientesListDto>()
                                .FirstOrDefault(c => c.IdCliente == editadoId);
                        _bindingSource.Position = _bindingSource.IndexOf(editadoCliente);
                        MessageBox.Show("Cliente editado",
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

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.FiltroActivo = true;
            tsbFiltrar.BackColor = Color.Orange;
            _estadoNavegacion.IrPrimera();
            RecargarGrilla();
        }
        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.FiltroActivo = false;
            tsbFiltrar.BackColor = Color.Orange;
            _estadoNavegacion.IrPrimera();
            RecargarGrilla();

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _estadoNavegacion.Inicializar();
            tsbFiltrar.BackColor = SystemColors.Control;
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
