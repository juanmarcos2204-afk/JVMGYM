using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using JVMGYM.Servicio.DTOs.Paginación;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IMetodoDePagoServicio
    {
        void Agregar(MetodosDePagoCreateDto metodosDePagoCreateDto);
        void Editar(MetodosDePagoEditDto metodosDePagoEditDto);
        void Eliminar(int metodoPagoId);
        List<MetodoDePagoListDto> ObtenerTodos();
        MetodoDePagoListDto ObtenerPorId(int metodoPagoId);
        MetodosDePagoEditDto ObtenerParaEditar(int metodoPagoId);
        List<MetodoDePagoListDto> ObtenerDatosCombo();
        ResultadoPaginacionDto<MetodoDePagoListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
