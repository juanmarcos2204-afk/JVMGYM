using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio : Repositorio<MetodosDePago>, IMetodosDePagoRepositorio
    {
        public MetodosDePagoRepositorio(AppDbContext context) : base(context)
        {
        }

        public bool Existe(MetodosDePago metodosDePago)
        {
            return _context.MetodosDePagos.Any(m => m.Nombre == metodosDePago.Nombre &&
                m.IdMetodoPago != metodosDePago.IdMetodoPago);
        }

        public bool TieneRegistrosRelacionados(int id)
        {
            return _context.Pagos.Any(p => p.IdMetodoPago == id);
        }

        public (List<MetodosDePago> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<MetodosDePago> query = _context.MetodosDePagos.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(m => m.Nombre.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderBy(m => m.Nombre).ThenBy(m => m.IdMetodoPago)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }
    }
}
