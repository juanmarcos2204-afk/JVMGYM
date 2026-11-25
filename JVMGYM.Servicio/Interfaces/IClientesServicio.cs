using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.DTOs.Paginación;

namespace JVMGYM.Servicio.Interfaces
{
    public interface IClientesServicio
    {
        void Agregar(ClienteCreateDto clienteCreateDto);
        void Editar(ClienteEditDto clienteEditDto);
        ClienteEditDto ObtenerParaEditar(int id);
        void Eliminar(int clienteId);
        List<ClientesListDto> ObtenerDatosCombo();
        List<ClientesListDto> FiltrarPorActivo(bool activo);
        List<ClientesListDto> ObtenerTodos();
        ResultadoPaginacionDto<ClientesListDto> ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}