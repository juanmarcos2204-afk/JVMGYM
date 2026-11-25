using JVMGYM.Servicio.Dtos.Metodos_de_pago;

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
    }
}
