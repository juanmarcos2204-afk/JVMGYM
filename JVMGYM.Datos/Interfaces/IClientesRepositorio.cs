using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IClientesRepositorio
    {
        List<Clientes> ObtenerTodos();
        Clientes ObtenerPorId(int id);
        void Agregar(Clientes clientes);
        void Editar(Clientes clientes);
        void Eliminar(Clientes clientes);
    }
}
