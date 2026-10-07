using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;

namespace JVMGYM.Servicio
{
    public class DuracionMembresiaServicio : IDuracionMembresiaServicio
    {
        private readonly IDuracionMembresiaRepositorio _duracionMembresiaRepositorio;
        public DuracionMembresiaServicio(IDuracionMembresiaRepositorio duracionMembresiaRepositorio)
        {
            _duracionMembresiaRepositorio = duracionMembresiaRepositorio;
        }
        public void Agregar(DuracionMembresiaCreateDto duracionMembresiaCreateDto)
        {
            DuracionMembresia duracionMembresia = duracionMembresiaCreateDto.ToEntidad();
            try
            {
                _duracionMembresiaRepositorio.Agregar(duracionMembresia);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Eliminar(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id de la duración de la membresia no puede ser menor a cero");
            }
            var duracionMembresia = _duracionMembresiaRepositorio.ObtenerPorId(id);

            if (duracionMembresia is null)
            {
                throw new KeyNotFoundException($"No se encontró una duración de la membresia con el ID {id}");
            }
            try
            {
                _duracionMembresiaRepositorio.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DuracionMembresiaListDto> ObtenerDatosCombo()
        {
            var lista = _duracionMembresiaRepositorio.ObtenerTodos().Select(dm => dm.ToListDto()).ToList();
            var defaultDuracionMembresia = new DuracionMembresiaListDto
            {
                IdDuracionMembresia = 0,
                Nombre = "Seleccione"
            };
            lista.Insert(0, defaultDuracionMembresia);
            return lista;
        }
        public List<DuracionMembresiaListDto> ObtenerTodos()
        {
            return _duracionMembresiaRepositorio.ObtenerTodos().Select(dm => dm.ToListDto()).ToList();

        }
    }
}
