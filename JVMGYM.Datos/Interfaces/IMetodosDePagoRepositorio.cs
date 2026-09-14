using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    internal interface IMetodosDePagoRepositorio
    {
        List<MetodosDePago> ObtenerTodos();
        MetodosDePago ObtenerPorId(int id);
        void Agregar(MetodosDePago metodosDePago);
        void Editar(MetodosDePago metodosDePago);
        void Eliminar(MetodosDePago metodosDePago);
    }
}
