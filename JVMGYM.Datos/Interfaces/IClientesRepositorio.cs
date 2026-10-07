using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IClientesRepositorio
    {
        List<Cliente> ObtenerTodos();
        Cliente? ObtenerPorId(int id);
        void Agregar(Cliente clientes);
        void Editar(Cliente clientes);
        void Eliminar(int clienteId);
        bool Existe(Cliente cliente);
        List<Cliente> FiltrarPorActivo(bool activo);
    }
}
