using JVMGYM.Datos;
using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Datos.UnitOfWork;
using JVMGYM.Servicio;
using JVMGYM.Servicio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows.Forms;

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

            var servicios = new ServiceCollection();
            //TODO: Pasar todo a una capa
            servicios
                .AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(connectionString),
                    ServiceLifetime.Scoped);

            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            servicios.AddScoped<IClientesRepositorio, ClientesRepositorio>();
            servicios.AddScoped<IMembresiasRepositorio, MembresiasRepositorio>();
            servicios.AddScoped<IDuracionMembresiaRepositorio, DuracionMembresiaRepositorio>();
            servicios.AddScoped<IMetodosDePagoRepositorio, MetodosDePagoRepositorio>();
            servicios.AddScoped<IPagosRepositorio, PagosRepositorio>();
            servicios.AddScoped<IClientesMembresiaRepositorio, ClientesMembresiaRepositorio>();

            servicios.AddScoped<IClientesServicio, ClientesServicio>();
            servicios.AddScoped<IMembresiaServicio, MembresiaServicio>();
            servicios.AddScoped<IDuracionMembresiaServicio, DuracionMembresiaServicio>();
            servicios.AddScoped<IMetodoDePagoServicio, MetodoDePagoServicio>();
            servicios.AddScoped<IPagosServicio, PagosServicio>();

            // Registro automático de formularios por reflexión
            var assembly = Assembly.GetExecutingAssembly();

            var tiposFormularios = assembly.GetTypes()
                .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var tipoForm in tiposFormularios)
            {
                servicios.AddTransient(tipoForm);
            }

            using var serviceProvider = servicios.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var frm = scope.ServiceProvider.GetRequiredService<frmPrincipal>();
            frm.Text = "Sistema de Gimnasio";

            Application.Run(frm);
        }
    }
}
