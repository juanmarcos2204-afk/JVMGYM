using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Pagos;
using JVMGYM.Servicio.DTOs.Paginación;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;

namespace JVMGYM.Servicio.Servicios
{
    public class PagosServicio : IPagosServicio
    {
        private readonly IPagosRepositorio _pagosRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public PagosServicio(IPagosRepositorio pagosRepositorio, IUnitOfWork unitOfWork)
        {
            _pagosRepositorio = pagosRepositorio;
            _unitOfWork = unitOfWork;
        }

        public void Agregar(PagoCreateDto pagoCreateDto)
        {
            Pago pago = pagoCreateDto.ToEntidad();
            try
            {
                _pagosRepositorio.Agregar(pago);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar un nuevo pago {ex.Message}");
            }
        }

        public void Editar(PagoEditDto pagoEditDto)
        {
            Pago pago = pagoEditDto.ToEntidad();
            if (pago.IdPago == 0)
            {
                throw new ArgumentOutOfRangeException("El Id del pago debe ser mayor a cero");
            }

            _pagosRepositorio.Editar(pago);
            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int pagoId)
        {
            if (pagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del pago no puede ser menor a cero");
            }

            var pago = _pagosRepositorio.ObtenerPorId(pagoId);
            if (pago is null)
            {
                throw new KeyNotFoundException($"No se encontró el pago con Id {pagoId}");
            }

            try
            {
                _pagosRepositorio.Eliminar(pagoId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PagoListDto> ObtenerTodos()
        {
            return _pagosRepositorio.ObtenerTodos().Select(p => p.ToListDto()).ToList();
        }

        public PagoListDto ObtenerPorId(int pagoId)
        {
            if (pagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del pago no puede ser menor a cero");
            }

            var pago = _pagosRepositorio.ObtenerPorId(pagoId);
            if (pago is null)
            {
                throw new KeyNotFoundException("No se encontró el Id proporcionado");
            }

            return pago.ToListDto();
        }

        public PagoEditDto ObtenerParaEditar(int pagoId)
        {
            if (pagoId <= 0)
            {
                throw new ArgumentException("El ID del pago debe ser un entero mayor a cero.", nameof(pagoId));
            }

            var pago = _pagosRepositorio.ObtenerPorId(pagoId);
            if (pago is null)
            {
                throw new ArgumentException(nameof(pagoId), $"Id {pagoId} no encontrado");
            }

            return pago.ToEditDto();
        }

        public ResultadoPaginacionDto<PagoListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            var resultado = _pagosRepositorio.ObtenerPagina(paginaActual,
                cantidadPorPagina, filtroActivo, textoBuscar);
            var listaDto = resultado.lista
                    .Select(p => p.ToListDto()).ToList();
            return new ResultadoPaginacionDto<PagoListDto>
            {
                Items = listaDto,
                TotalRegistros = resultado.cantidadRegistros,
                CantidadPorPagina = cantidadPorPagina,
                PaginaActual = paginaActual
            };
        }
    }
}
