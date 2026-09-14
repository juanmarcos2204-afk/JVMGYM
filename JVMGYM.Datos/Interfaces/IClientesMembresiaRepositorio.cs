using JVMGYM.Datos.Repositorios;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IClientesMembresiaRepositorio
    {
        List<ClientesMembresia> ObtenerTodos();
    }
}
