using JVMGYM.Datos.Interfaces;

namespace JVMGYM.Datos.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
