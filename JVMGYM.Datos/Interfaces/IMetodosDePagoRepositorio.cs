using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMetodosDePagoRepositorio : IRepositorio<MetodosDePago>
    {
        bool Existe(MetodosDePago metodosDePago);
        bool TieneRegistrosRelacionados(int id);
    }
}
