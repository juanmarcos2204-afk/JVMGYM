using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class PagosRepositorio : Repositorio<Pago>, IPagosRepositorio
    {
        public PagosRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
