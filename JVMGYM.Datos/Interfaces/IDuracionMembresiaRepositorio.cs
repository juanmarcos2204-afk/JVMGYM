using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IDuracionMembresiaRepositorio : IRepositorio<DuracionMembresia>
    {
        bool TieneRegistrosRelacionados(int id);
        (List<DuracionMembresia> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
