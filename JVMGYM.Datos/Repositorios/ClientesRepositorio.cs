using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace JVMGYM.Datos.Repositorios
{
    public class ClientesRepositorio : Repositorio<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(AppDbContext context) : base(context)
        {
        }

        public bool Existe(Cliente cliente)
        {
            return _context.Clientes.Any(c => c.DNI == cliente.DNI &&
                c.IdCliente != cliente.IdCliente);
        }

        public List<Cliente> FiltrarPorActivo(bool activo)
        {
            return _context.Clientes.Where(c => c.Activo == activo).ToList();
        }

        public (List<Cliente> lista, int cantidadRegistros) ObtenerPagina(int paginaActual, int cantidadPorPagina, 
            bool? filtroActivo = null, string? textoBuscar = null)
        {
            IQueryable<Cliente> query = _context.Clientes.AsNoTracking();
            if (filtroActivo is not null)
            {
                query = query.Where(c => c.Activo == filtroActivo);
            }
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                query = query.Where(c => c.Nombre.Contains(textoBuscar));
            }
            var cantidad = query.Count();
            var lista = query
                .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                .Skip(cantidadPorPagina * (paginaActual - 1))
                .Take(cantidadPorPagina)
                .ToList();
            return (lista, cantidad);
        }
    }
}
