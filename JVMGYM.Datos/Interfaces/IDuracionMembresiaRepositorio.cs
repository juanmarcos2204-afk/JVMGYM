using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IDuracionMembresiaRepositorio
    {
        List<DuracionMembresia> ObtenerTodos();
        void Agregar(DuracionMembresia duracionMembresia);
        void Eliminar(int id);
        DuracionMembresia? ObtenerPorId(int id);

    }
}
