using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Membresias;
using JVMGYM.Servicio.Interfaces;
using JVMGYM.Servicio.Mapeadores;
namespace JVMGYM.Servicio
{
    public class ClientesServicio : IClientesServicio
    {
        private readonly IClientesRepositorio _clienteRepositorio;
        public ClientesServicio(IClientesRepositorio clientesRepositorio)
        {
            _clienteRepositorio = clientesRepositorio;
        }
        public void Agregar(ClienteCreateDto clienteCreateDto)
        {
            Cliente clientes = clienteCreateDto.ToEntidad();
            try
            {
                _clienteRepositorio.Agregar(clientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Editar(ClienteEditDto clienteEditDto)
        {
            if (clienteEditDto.IdCliente == 0)
                throw new ArgumentOutOfRangeException("El Id del Cliente debe ser mayor a cero");
            if (clienteEditDto.Nombre.Equals(clienteEditDto.Nombre)) throw new ArgumentException("Ya existe ese mismo Cliente");
            Cliente clientes = clienteEditDto.ToEntidad();
            _clienteRepositorio.Editar(clientes);
        }
        public void Eliminar(int clienteId)
        {
            if (clienteId <= 0)
            {
                throw new ArgumentOutOfRangeException("El Id del cliente no puede ser menor a cero");
            }
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
                throw new Exception(ex.Message);
            }
        }
        public List<ClientesListDto> ObtenerTodos()
        {
            return _clienteRepositorio.ObtenerTodos().Select(c => c.ToListDto()).ToList();
        }
    }
}
