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

    }
}
