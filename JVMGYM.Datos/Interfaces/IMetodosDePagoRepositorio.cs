using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMetodosDePagoRepositorio : IRepositorio<MetodosDePago>
    {
        bool Existe(MetodosDePago metodosDePago);
        bool TieneRegistrosRelacionados(int id);
        (List<MetodosDePago> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
