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

        public (List<Pago> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<Pago> query = _context.Pagos
                .Include(p => p.Clientes)
                .Include(p => p.MetodosDePago)
                .AsNoTracking();
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(p => p.Clientes.Nombre.Contains(textoBuscar)
                    || p.Clientes.Apellido.Contains(textoBuscar)
                    || p.MetodosDePago.Nombre.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderByDescending(p => p.Fecha).ThenBy(p => p.IdPago)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }
    }
}
