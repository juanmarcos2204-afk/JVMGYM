using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

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
    }
}
