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

        public virtual void Agregar(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Editar(T entity)
        {
            var entityType = _context.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException($"No se encontró el modelo de {typeof(T).Name}.");
            var primaryKey = entityType.FindPrimaryKey()
                ?? throw new InvalidOperationException($"{typeof(T).Name} no tiene clave primaria.");

            var nombrePropiedadId = primaryKey.Properties[0].Name;
            var propiedadId = typeof(T).GetProperty(nombrePropiedadId)
                ?? throw new InvalidOperationException($"No se encontró la propiedad {nombrePropiedadId} en {typeof(T).Name}.");
            var id = (int)propiedadId.GetValue(entity)!;

            var entidadEnDb = _dbSet.Find(id)
                ?? throw new KeyNotFoundException($"No se encuentra {typeof(T).Name} con ID: {id}");

            _context.Entry(entidadEnDb).CurrentValues.SetValues(entity);
        }

        public virtual void Eliminar(int id)
        {
            var entidadEnDb = _dbSet.Find(id)
                ?? throw new KeyNotFoundException($"No se encuentra {typeof(T).Name} con ID: {id}");

            _dbSet.Remove(entidadEnDb);
        }
    }
}
