using JVMGYM.Servicio.Dtos.Clientes;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IClientesServicio
    {
        void Agregar(ClienteCreateDto clienteCreateDto);
        void Editar(ClienteEditDto clienteEditDto);
        void Eliminar(int clienteId);
        List<ClientesListDto> ObtenerTodos();
    }
}