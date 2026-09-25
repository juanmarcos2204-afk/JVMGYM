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
        public List<Clientes> ObtenerTodos()
        {
            return _context.Clientes.ToList();
        }

        public Clientes ObtenerPorId(int id)
        {
            return _context.Clientes.Find(id);
        }
        public void Agregar(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            _context.SaveChanges();
        }
        public void Editar(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            _context.SaveChanges();
        }
        public void Eliminar(Clientes clientes)
        {
            _context.Clientes.Remove(clientes);
            _context.SaveChanges();
        }
    }
}