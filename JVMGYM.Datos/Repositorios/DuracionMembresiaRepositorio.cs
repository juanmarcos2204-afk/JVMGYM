using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class DuracionMembresiaRepositorio : Repositorio<DuracionMembresia>, IDuracionMembresiaRepositorio
    {
        public DuracionMembresiaRepositorio(AppDbContext context) : base(context)
        {
        }

        public bool TieneRegistrosRelacionados(int id)
        {
            return _context.Membresias.Any(m => m.IdDuracionMembresia == id);
        }
    }
}
