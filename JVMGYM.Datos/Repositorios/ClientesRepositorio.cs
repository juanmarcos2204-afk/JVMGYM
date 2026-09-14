using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
namespace JVMGYM.Datos.Repositorios
{
    public class ClientesRepositorio:IClientesRepositorio
    {
        public List<Clientes> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.Clientes.ToList();
            }
        }

        public Clientes ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Clientes.Find(id);
            }
        }
        public void Agregar(Clientes clientes)
        {
            using (var context = new AppDbContext())
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();
            }
        }
        public void Editar(Clientes clientes)
        {
            using (var context = new AppDbContext())
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();
            }
        }
        public void Actualizar(Clientes clientes)
        {
            using (var context = new AppDbContext())
            {
                context.Clientes.Update(clientes);
                context.SaveChanges();
            }
        }
        public void Eliminar(Clientes clientes)
        {
            using (var context = new AppDbContext())
            {
                context.Clientes.Remove(clientes);
                context.SaveChanges();
            }
        }
    }
}