using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using JVMGYM.Servicio.DTOs.Paginación;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;

namespace JVMGYM.Servicio.Servicios
{
    public class MetodoDePagoServicio : IMetodoDePagoServicio
    {
        private readonly IMetodosDePagoRepositorio _metodosDePagoRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public MetodoDePagoServicio(IMetodosDePagoRepositorio metodosDePagoRepositorio, IUnitOfWork unitOfWork)
        {
            _metodosDePagoRepositorio = metodosDePagoRepositorio;
            _unitOfWork = unitOfWork;
        }

        public void Agregar(MetodosDePagoCreateDto metodosDePagoCreateDto)
        {
            MetodosDePago metodosDePago = metodosDePagoCreateDto.ToEntidad();
            try
            {
                _metodosDePagoRepositorio.Agregar(metodosDePago);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar un nuevo método de pago {ex.Message}");
            }
        }

        public void Editar(MetodosDePagoEditDto metodosDePagoEditDto)
        {
            MetodosDePago metodosDePago = metodosDePagoEditDto.ToEntidad();
            if (metodosDePagoEditDto.IdMetodoPago == 0)
            {
                throw new ArgumentOutOfRangeException("El Id del método de pago debe ser mayor a cero");
            }

            if (_metodosDePagoRepositorio.Existe(metodosDePago))
            {
                throw new ArgumentException("Metodo de pago ya existente");
            }

            _metodosDePagoRepositorio.Editar(metodosDePago);
            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int metodoPagoId)
        {
            if (metodoPagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del método de pago no puede ser menor a cero");
            }

            if (_metodosDePagoRepositorio.TieneRegistrosRelacionados(metodoPagoId))
            {
                throw new InvalidOperationException($"No se puede eliminar el método de pago {metodoPagoId} porque tiene pagos asociados.");
            }

            var metodo = _metodosDePagoRepositorio.ObtenerPorId(metodoPagoId);
            if (metodo is null)
            {
                throw new KeyNotFoundException("No se encontró el Id proporcionado");
            }

            try
            {
                _metodosDePagoRepositorio.Eliminar(metodoPagoId);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MetodoDePagoListDto> ObtenerTodos()
        {
            return _metodosDePagoRepositorio.ObtenerTodos().Select(m => m.ToListDto()).ToList();
        }

        public MetodoDePagoListDto ObtenerPorId(int metodoPagoId)
        {
            if (metodoPagoId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del método de pago no puede ser menor a cero");
            }

            var metodo = _metodosDePagoRepositorio.ObtenerPorId(metodoPagoId);
            if (metodo is null)
            {
                throw new KeyNotFoundException("No se encontró el Id proporcionado");
            }

            return metodo.ToListDto();
        }

        public MetodosDePagoEditDto ObtenerParaEditar(int metodoPagoId)
        {
            if (metodoPagoId <= 0)
            {
                throw new ArgumentException("El ID del método de pago debe ser un entero mayor a cero.", nameof(metodoPagoId));
            }

            var metodo = _metodosDePagoRepositorio.ObtenerPorId(metodoPagoId);
            if (metodo is null)
            {
                throw new ArgumentException(nameof(metodoPagoId), $"Id {metodoPagoId} no encontrado");
            }

            return new MetodosDePagoEditDto
            {
                IdMetodoPago = metodo.IdMetodoPago,
                Nombre = metodo.Nombre
            };
        }

        public List<MetodoDePagoListDto> ObtenerDatosCombo()
        {
            var lista = _metodosDePagoRepositorio.ObtenerTodos().Select(m => m.ToListDto()).ToList();
            lista.Insert(0, new MetodoDePagoListDto
            {
                IdMetodoPago = 0,
                Nombre = "Seleccione"
            });
            return lista;
        }

        public ResultadoPaginacionDto<MetodoDePagoListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null, string? textoBuscar = null)
        {
            var resultado = _metodosDePagoRepositorio.ObtenerPagina(paginaActual,
                cantidadPorPagina, filtroActivo, textoBuscar);
            var listaDto = resultado.lista
                    .Select(m => m.ToListDto()).ToList();
            return new ResultadoPaginacionDto<MetodoDePagoListDto>
            {
                Items = listaDto,
                TotalRegistros = resultado.cantidadRegistros,
                CantidadPorPagina = cantidadPorPagina,
                PaginaActual = paginaActual
            };
        }
    }
}
