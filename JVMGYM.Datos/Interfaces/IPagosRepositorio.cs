using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IPagosRepositorio
    {
        List<Pagos> ObtenerTodos();
        Pagos? ObtenerPorId(int id);
        void Agregar(Pagos pagos);
        void Editar(Pagos pagos);
        void Eliminar(int pagosId);

    }
}
