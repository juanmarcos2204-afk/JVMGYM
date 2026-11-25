using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;

namespace JVMGYM.Datos.Repositorios
{
    public class PagosRepositorio : Repositorio<Pago>, IPagosRepositorio
    {
        public PagosRepositorio(AppDbContext context) : base(context)
        {
        }

        public override List<Pago> ObtenerTodos()
        {
            return _context.Pagos
                .Include(p => p.Clientes)
                .Include(p => p.MetodosDePago)
                .ToList();
        }
    }
}
