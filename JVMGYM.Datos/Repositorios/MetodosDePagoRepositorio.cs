using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio : Repositorio<MetodosDePago>, IMetodosDePagoRepositorio
    {
        public MetodosDePagoRepositorio(AppDbContext context) : base(context)
        {
        }
    }
}
