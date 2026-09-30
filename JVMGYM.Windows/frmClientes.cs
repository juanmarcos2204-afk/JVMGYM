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
                _clientesServicio.Agregar(clienteCreateDto);
                MessageBox.Show("Cliente Añadido",
                    "Mensaje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                RecargarGrilla();
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
    }
}
