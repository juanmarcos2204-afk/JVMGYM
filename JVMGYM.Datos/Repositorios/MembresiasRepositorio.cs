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

        public (List<Membresia> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<Membresia> query = _context.Membresias
                .Include(m => m.DuracionMembresia)
                .AsNoTracking();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(m => m.Tipo.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderBy(m => m.Tipo).ThenBy(m => m.IdMembresia)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }
    }
}
