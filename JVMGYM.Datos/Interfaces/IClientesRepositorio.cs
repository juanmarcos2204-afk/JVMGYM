using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IClientesRepositorio : IRepositorio<Cliente>
    {
        bool Existe(Cliente cliente);
        List<Cliente> FiltrarPorActivo(bool activo);
        (List<Cliente> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
