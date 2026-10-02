using JVMGYM.Datos;
using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Servicio;
using JVMGYM.Servicio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JVMGYM.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            IConfiguration configuration =
                new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile(
                        "appsettings.json",
                        optional: false,
                        reloadOnChange: true)
                    .Build();

            string connectionString =
                configuration.GetConnectionString("Gimnasios")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena de conexión.");

            var options =
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(connectionString)
                    .Options;

            var context =
                new AppDbContext(options);
            //RÉPOS
            IClientesRepositorio clienteRepositorio = new ClientesRepositorio(context);
            IMembresiasRepositorio membresiaRepositorio = new MembresiasRepositorio(context);
            //SERVICIOS
            IClientesServicio clienteServicio = new ClientesServicio(clienteRepositorio);
            IMembresiaServicio membresiaServicio = new MembresiaServicio(membresiaRepositorio);

            Application.Run(new frmPrincipal(clienteServicio,
                membresiaServicio));
        }
    }
}