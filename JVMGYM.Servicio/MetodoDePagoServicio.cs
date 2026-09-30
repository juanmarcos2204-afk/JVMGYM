using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using JVMGYM.Servicio.Mapeadores;
namespace JVMGYM.Servicio
{
    public class MetodoDePagoServicio
    {
        private readonly IMetodosDePagoRepositorio _metodosDePagoRepositorio;

        public MetodoDePagoServicio(IMetodosDePagoRepositorio metodosDePagoRepositorio)
        {
            _metodosDePagoRepositorio = metodosDePagoRepositorio;
        }

        public void Agregar(MetodosDePagoCreateDto metodosDePagoCreateDto)
        {
            MetodosDePago metodosDePago = metodosDePagoCreateDto.ToEntidad();
            try
            {
                _metodosDePagoRepositorio.Agregar(metodosDePago);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al agregar un nuevo método de pago {ex.Message}");
            }
        }

        public void Editar(MetodosDePagoEditDto metodosDePagoEditDto)
        {
            MetodosDePago metodos = metodosDePagoEditDto.ToEntidad();
            if (metodosDePagoEditDto.idMetodoPago == 0)
                throw new ArgumentOutOfRangeException("El Id de la Membresia debe ser mayor a cero");
            if (metodosDePagoEditDto.Nombre.Equals(metodos.Nombre)) throw new ArgumentException("Ya existe esa misma membresia");
            _metodosDePagoRepositorio.Editar(metodos);
        }

        public void Eliminar(int metodoPagoId)
        {
            if (metodoPagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no puede ser menor a cero");
            }

            var metodo = _metodosDePagoRepositorio.ObtenerPorId(metodoPagoId);
            if (metodo is null)
                throw new KeyNotFoundException("No se encontró el Id proporcionado");
            try
            {
                _metodosDePagoRepositorio.Eliminar(metodoPagoId);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MetodoDePagoListDto> ObtenerTodos()
        {
            return ObtenerTodos().Select(m => m.ToListDto()).ToList();
        }

        public MetodoDePagoListDto ObtenerPorId(int metodoPagoId)
        {
            if (metodoPagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no puede ser menor a cero");
            }
            var metodosDePago = _metodosDePagoRepositorio.ObtenerPorId(metodoPagoId);
            if (metodosDePago is null)
                throw new KeyNotFoundException("No se encontró la membresia");
            return metodosDePago.ToListDto();

        }

    }
}
