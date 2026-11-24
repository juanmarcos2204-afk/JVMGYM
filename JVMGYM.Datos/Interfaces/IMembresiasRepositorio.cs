using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IMembresiasRepositorio : IRepositorio<Membresia>
    {
        bool Existe(Membresia membresia);
    }
}
