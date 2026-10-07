using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;
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
        private readonly IClientesServicio _clientesServicio;
        private BindingSource _bindingSource = new BindingSource();
        public frmClientes(IClientesServicio clientesServicio)
        {
            InitializeComponent();
            _clientesServicio = clientesServicio;
        }
        private void frmClientes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            var resultado = _clientesServicio.ObtenerTodos();
            MostrarDatosGrilla(resultado);
        }

        private void MostrarDatosGrilla(List<ClientesListDto> resultado)
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
            using (var frm = new frmClientesAe { Text = "Ingreso de Cliente" })
            {
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
            using (frmClientesAe frm = new frmClientesAe() { Text = "Editar Cliente" })
            {
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

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = _clientesServicio.FiltrarPorActivo(true);
            MostrarDatosGrilla(resultado);
            ManejarBotones(true);
        }
        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = _clientesServicio.FiltrarPorActivo(false);
            MostrarDatosGrilla(resultado);
            ManejarBotones(true);

        }
        private void ManejarBotones(bool filtrado)
        {
            tsbNuevo.Enabled = !filtrado;
            tsbBorrar.Enabled = !filtrado;
            tsbEditar.Enabled = !filtrado;

            tsbFiltrar.BackColor = filtrado ? Color.Orange : SystemColors.Control;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
            ManejarBotones(false);
        }
    }
}