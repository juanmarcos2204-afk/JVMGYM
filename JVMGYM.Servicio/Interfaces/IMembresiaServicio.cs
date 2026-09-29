using JVMGYM.Servicio.Dtos.Membresias;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IMembresiaServicio
    {
        void Agregar(MembresiaCreateDto membresiaCreateDto);
        void Editar(MembresiaEditDto membresiaEditDto);
        void Eliminar(int membresiaId);
        List<MembresiaListDto> ObtenerTodos();
    }
}