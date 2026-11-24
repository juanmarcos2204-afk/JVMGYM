using JVMGYM.Datos.Interfaces;
using JVMGYM.Datos.Repositorios;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;

namespace JVMGYM.Servicio
{
    public class MembresiaServicio : IMembresiaServicio
    {
        private readonly IMembresiasRepositorio _membresiasRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public MembresiaServicio(IMembresiasRepositorio membresiasRepositorio, IUnitOfWork unitOfWork)
        {
            _membresiasRepositorio = membresiasRepositorio;
            _unitOfWork = unitOfWork;
        }

        public void Agregar(MembresiaCreateDto membresiaCreateDto)
        {
            Membresia membresia = membresiaCreateDto.ToEntidad();
            if (_membresiasRepositorio.Existe(membresia))
            {
                throw new ArgumentException("Membresia ya existente");
            }
            try
            {
                _membresiasRepositorio.Agregar(membresia);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al agregar una nueva membresia {ex.Message}");
            }
        }

        public void Editar(MembresiaEditDto membresiaEditDto)
        {
            Membresia membresia = membresiaEditDto.ToEntidad();
            if (membresia.IdMembresia == 0)
                throw new ArgumentOutOfRangeException("El Id de la Membresia debe ser mayor a cero");
            if (_membresiasRepositorio.Existe(membresia))
            {
                throw new ArgumentException("Membresia ya existente");
            }
            _membresiasRepositorio.Editar(membresia);
            _unitOfWork.SaveChanges();
        }

        public void Eliminar(int membresiaId)
        {
            if (membresiaId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no puede ser menor a cero");
            }

            var membresia = _membresiasRepositorio.ObtenerPorId(membresiaId);
            if (membresia is null)
                throw new KeyNotFoundException("No se encontró el Id proporcionado");
            try
            {
                _membresiasRepositorio.Eliminar(membresiaId);
                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<MembresiaListDto> ObtenerTodos()
        {
            return _membresiasRepositorio.ObtenerTodos().Select(m => m.ToListDto()).ToList();
        }

        public MembresiaListDto ObtenerPorId(int membresiaId)
        {
            if (membresiaId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no puede ser menor a cero");
            }
            var membresia = _membresiasRepositorio.ObtenerPorId(membresiaId);
            if (membresia is null)
                throw new KeyNotFoundException("No se encontró la membresia");
            return membresia.ToListDto();

        }

        public MembresiaEditDto? ObtenerParaEditar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la membresia debe ser un entero mayor a cero.", nameof(id));
            Membresia? membresia = _membresiasRepositorio.ObtenerPorId(id);
            if (membresia is null) throw new ArgumentException(nameof(id), $"Id {id} no encontrado");
            MembresiaEditDto membresiaEditDto = membresia.ToEditDto();
            return membresiaEditDto;
        }
    }
}
