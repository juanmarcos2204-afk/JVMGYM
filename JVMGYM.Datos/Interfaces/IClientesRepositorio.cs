using JVMGYM.Entidades;

namespace JVMGYM.Datos.Interfaces
{
    public interface IClientesRepositorio : IRepositorio<Cliente>
    {
        bool Existe(Cliente cliente);
        List<Cliente> FiltrarPorActivo(bool activo);
    }
}
