using JVMGYM.Servicio;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.Interfaces;
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
        private BindingSource _bindingSource = new BindingSource();
        public frmDuracionMembresias(IDuracionMembresiaServicio duracionMembresiaServicio)
        {
            InitializeComponent();
            _duracionMembresiaServicio = duracionMembresiaServicio;
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
            var resultado = _duracionMembresiaServicio.ObtenerTodos();
            MostrarDatosGrilla(resultado);
        }

        private void MostrarDatosGrilla(List<DuracionMembresiaListDto> resultado)
        {
            _bindingSource.DataSource = resultado;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDuracionMembresiasAe { Text = "Ingreso de Duración de Membresias" })
            {
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
    }
}
