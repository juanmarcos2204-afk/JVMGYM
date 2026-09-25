using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMembresiasRepositorio
    {
        List<Membresias> ObtenerTodos();
        Membresias? ObtenerPorId(int id);
        void Agregar(Membresias membresias);
        void Editar(Membresias membresias);

        //ELIMINAMOS REGISTROS POR ID
        void Eliminar(int membresiaId);
    }
}