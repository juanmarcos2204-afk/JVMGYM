using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMembresiasRepositorio
    {
        List<Membresia> ObtenerTodos();
        Membresia? ObtenerPorId(int id);
        void Agregar(Membresia membresias);
        void Editar(Membresia membresias);

        //ELIMINAMOS REGISTROS POR ID
        void Eliminar(int membresiaId);
    }
}