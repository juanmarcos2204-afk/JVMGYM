using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Mapeadores;
namespace JVMGYM.Servicio
{
    public class ClientesServicio
    {
        private readonly IClientesRepositorio _clienteRepositorio;
        public ClientesServicio(IClientesRepositorio clientesRepositorio)
        {
            _clienteRepositorio = clientesRepositorio;
        }
        public void Agregar (ClienteCreateDto clienteCreateDto)
        {
            Clientes clientes = clienteCreateDto.ToEntidad();
            try
            {
                _clienteRepositorio.Agregar(clientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar (ClienteEditDto clienteEditDto)
        {
            Clientes clientes = clienteEditDto.ToEntidad();
            _clienteRepositorio.Editar(clientes);
        }
        public void Eliminar (int clienteId)
        {
            var cliente = _clienteRepositorio.ObtenerPorId(clienteId);
            if (cliente is null)
            {
                throw new KeyNotFoundException($"No se encontró un cliente con el ID {clienteId}");
            }
            try
            {
                _clienteRepositorio.Eliminar(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public List<ClientesListDto> ObtenerTodos()
        {
            return _clienteRepositorio.ObtenerTodos().Select(c => c.ToListDto()).ToList();
        }
    }
}
