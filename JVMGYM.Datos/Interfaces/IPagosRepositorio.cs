using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IPagosRepositorio
    {
        List<Pago> ObtenerTodos();
        Pago? ObtenerPorId(int id);
        void Agregar(Pago pagos);
        void Editar(Pago pagos);
        void Eliminar(int pagosId);

    }
}
