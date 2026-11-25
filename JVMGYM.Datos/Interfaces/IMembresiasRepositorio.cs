using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMembresiasRepositorio : IRepositorio<Membresia>
    {
        bool Existe(Membresia membresia);
        (List<Membresia> lista, int cantidadRegistros) ObtenerPagina(int paginaActual,
            int cantidadPorPagina, bool? filtroActivo = null,
            string? textoBuscar = null);
    }
}
