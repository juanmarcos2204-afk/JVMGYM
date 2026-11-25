using JVMGYM.Servicio.Dtos.Pagos;
using JVMGYM.Servicio.DTOs.Paginación;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IPagosServicio
    {
        void Agregar(PagoCreateDto pagoCreateDto);
        void Editar(PagoEditDto pagoEditDto);
        void Eliminar(int pagoId);
        List<PagoListDto> ObtenerTodos();
        PagoListDto ObtenerPorId(int pagoId);
        PagoEditDto ObtenerParaEditar(int pagoId);
        ResultadoPaginacionDto<PagoListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
