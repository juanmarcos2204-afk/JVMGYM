using JVMGYM.Datos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JVMGYM.Datos.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual List<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        public virtual T? ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public virtual void Editar(T entidad)
        {
            var entidadEnDb = _dbSet.Find(entidad);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException($"No se encuentra {entidad}");
            }
            _context.Entry(entidadEnDb).CurrentValues.SetValues(entidad);
        }

        public virtual void Eliminar(int id)
        {
            var entidadEnDb = _dbSet.Find(id);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException($"No se encuentra entidad con ID {id}");
            }
            _dbSet.Remove(entidadEnDb);
        }
    }
}
