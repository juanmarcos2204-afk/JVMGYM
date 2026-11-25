using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;

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

        public (List<DuracionMembresia> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<DuracionMembresia> query = _context.DuracionesMembresias.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(d => d.Nombre.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderBy(d => d.Nombre).ThenBy(d => d.IdDuracionMembresia)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }
    }
}
