using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.DTOs.Paginación;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IMembresiaServicio
    {
        void Agregar(MembresiaCreateDto membresiaCreateDto);
        void Editar(MembresiaEditDto membresiaEditDto);
        void Eliminar(int membresiaId);
        List<MembresiaListDto> ObtenerTodos();
        MembresiaListDto ObtenerPorId(int membresiaId);
        MembresiaEditDto? ObtenerParaEditar(int idMembresia);
        ResultadoPaginacionDto<MembresiaListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}