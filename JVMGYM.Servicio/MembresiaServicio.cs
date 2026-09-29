using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;

namespace JVMGYM.Servicio
{
    public class MembresiaServicio : IMembresiaServicio
    {
        private readonly IMembresiasRepositorio _membresiasRepositorio;

        public MembresiaServicio(IMembresiasRepositorio membresiasRepositorio)
        {
            _membresiasRepositorio = membresiasRepositorio;
        }

        public void Agregar(MembresiaCreateDto membresiaCreateDto)
        {
            Membresia membresia = membresiaCreateDto.ToEntidad();
            try
            {
                _membresiasRepositorio.Agregar(membresia);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error al agregar una nueva membresia {ex.Message}");
            }
        }

        public void Editar(MembresiaEditDto membresiaEditDto)
        {
            Membresia membresia = membresiaEditDto.ToEntidad();
            if (membresiaEditDto.IdMembresia == 0)
                throw new ArgumentOutOfRangeException("El Id de la Membresia debe ser mayor a cero");
            if (membresiaEditDto.Tipo.Equals(membresia.Tipo)) throw new ArgumentException("Ya existe esa misma membresia");
            _membresiasRepositorio.Editar(membresia);
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
    }
}
