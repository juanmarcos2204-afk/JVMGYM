using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
namespace JVMGYM.Datos.Repositorios
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private readonly AppDbContext _context;
        public ClientesRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Clientes clientes)
        {
            _context.Add(clientes);
            _context.SaveChanges();
        }

        public void Editar(Clientes clientes)
        {
            var clienteEnDb = _context.Clientes.Find(clientes.IdCliente);
            if (clienteEnDb is null) throw new KeyNotFoundException($"No se encuentra un cliente con ID: {clientes.IdCliente}");
            clienteEnDb.Nombre = clientes.Nombre;
            clienteEnDb.Apellido = clientes.Apellido;
            clienteEnDb.DNI = clientes.DNI;
            clienteEnDb.Telefono = clientes.Telefono;
            clienteEnDb.Domicilio = clientes.Domicilio;
            clienteEnDb.FechaAlta = clientes.FechaAlta;

            _context.SaveChanges() ;
        }

        public void Eliminar(int clienteId)
        {
            var clienteEnDb = _context.Clientes.Find(clienteId);
            if (clienteEnDb is null) throw new KeyNotFoundException($"No se encuentra un cliente con ID: {clienteId}");
            _context.Clientes.Remove(clienteEnDb);
            _context.SaveChanges();

        }

        public Clientes? ObtenerPorId(int id)
        {
            return _context.Clientes
                .FirstOrDefault(c => c.IdCliente == id);
        }

        public List<Clientes> ObtenerTodos()
        {
            return _context.Clientes.ToList();
        }
    } 
}