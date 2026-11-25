using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IDuracionMembresiaRepositorio : IRepositorio<DuracionMembresia>
    {
        bool TieneRegistrosRelacionados(int id);
    }
}
