using Microsoft.Extensions.DependencyInjection;

namespace JVMGYM.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public frmPrincipal(IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _scopeFactory = scopeFactory;
        }

        private void AbrirFormulario<TForm>(string titulo) where TForm : Form
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<TForm>())
                {
                    frm.Text = titulo;
                    frm.ShowDialog();
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmClientes>("Listado de Clientes");
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmMembresias>("Listado de Membresias");
        }

        private void btnDuracionMembresia_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmDuracionMembresias>("Listado de Duración de Membresias");
        }

        private void btnMetodosDePago_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmMetodosDePago>("Listado de Métodos de Pago");
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmPagos>("Listado de Pagos");
        }
    }
}
