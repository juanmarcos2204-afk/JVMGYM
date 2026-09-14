using JVMGYM.Entidades;
using Microsoft.Identity.Client;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio
    {
        public List<MetodosDePago> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.MetodosDePagos.ToList();
            }
        }
        public MetodosDePago? ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.MetodosDePagos.Find(id);
            }
        }
        public void Agregar(MetodosDePago metodosDePago)
        {
            using ( var context = new AppDbContext())
            {
                context.MetodosDePagos.Add(metodosDePago);
                context.SaveChanges();
            }
        }
        public void Editar(MetodosDePago metodosDePago)
        {
            using (var context = new AppDbContext())
            {
                context.MetodosDePagos.Update(metodosDePago);
                context.SaveChanges();
            }
        }
        public void Eliminar(MetodosDePago metodosDePago)
        {
            using (var context = new AppDbContext())
            {
                context.MetodosDePagos.Remove(metodosDePago);
            }
        }
    }
    
}
