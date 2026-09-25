using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio
    {
        private readonly AppDbContext _context;
        public MetodosDePagoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public List<MetodosDePago> ObtenerTodos()
        {
            return _context.MetodosDePagos.ToList();
        }
        public MetodosDePago? ObtenerPorId(int id)
        {
            return _context.MetodosDePagos.Find(id);
        }
        public void Agregar(MetodosDePago metodosDePago)
        {
            _context.MetodosDePagos.Add(metodosDePago);
            _context.SaveChanges();
        }
        public void Editar(MetodosDePago metodosDePago)
        {
            _context.MetodosDePagos.Update(metodosDePago);
            _context.SaveChanges();
        }
        public void Eliminar(MetodosDePago metodosDePago)
        {
            _context.MetodosDePagos.Remove(metodosDePago);
            _context.SaveChanges();
        }
    }

}
