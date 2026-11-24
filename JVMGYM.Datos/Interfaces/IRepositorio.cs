namespace JVMGYM.Datos.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ObtenerTodos();
        T? ObtenerPorId(int id);
        void Agregar(T entity);
        void Editar(T entity);
        void Eliminar(int id);
    }
}
