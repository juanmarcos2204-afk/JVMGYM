using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IPagosRepositorio : IRepositorio<Pago>
    {
        (List<Pago> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
