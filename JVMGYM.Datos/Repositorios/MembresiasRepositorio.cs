using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;

namespace JVMGYM.Datos.Repositorios
{
    public class MembresiasRepositorio : Repositorio<Membresia>, IMembresiasRepositorio
    {
        public MembresiasRepositorio(AppDbContext context) : base(context)
        {
        }

        public override List<Membresia> ObtenerTodos()
        {
            return _context.Membresias
                .Include(m => m.DuracionMembresia)
                .ToList();
        }

        public bool Existe(Membresia membresia)
        {
            return _context.Membresias.Any(m => m.Tipo == membresia.Tipo &&
                m.IdMembresia != membresia.IdMembresia);
        }
    }
}
