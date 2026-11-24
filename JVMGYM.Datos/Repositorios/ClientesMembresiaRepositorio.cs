using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class ClientesMembresiaRepositorio : Repositorio<ClientesMembresia>, IClientesMembresiaRepositorio
    {
        public ClientesMembresiaRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
