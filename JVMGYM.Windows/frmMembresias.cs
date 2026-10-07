using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Membresias;
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
    public partial class frmMembresias : Form
    {
        private readonly IMembresiaServicio _membresiaServicio;
        private readonly IDuracionMembresiaServicio _duracionMembresiaServicio;
        private BindingSource _bindingSource = new BindingSource();
        public frmMembresias(IMembresiaServicio membresiaServicio,
            IDuracionMembresiaServicio duracionMembresiaServicio)
        {
            InitializeComponent();
            _membresiaServicio = membresiaServicio;
            _duracionMembresiaServicio = duracionMembresiaServicio;
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
            var resultado = _membresiaServicio.ObtenerTodos();
            MostrarDatosGrilla(resultado);
        }

        private void MostrarDatosGrilla(List<MembresiaListDto> resultado)
        {
            _bindingSource.DataSource = resultado;
            dgvDatos.DataSource = _bindingSource;
            lblCantidad.Text = resultado.Count.ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMembresiasAe(_duracionMembresiaServicio) { Text = "Ingreso de Membresia" })
            {
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
            using (var frm = new frmMembresiasAe(_duracionMembresiaServicio) { Text = "Editar Membresia" })
            {
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
}

