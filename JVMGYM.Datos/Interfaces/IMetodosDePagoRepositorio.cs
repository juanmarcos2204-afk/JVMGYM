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
        //ELIMINAMOS REGISTROS POR ID
        void Eliminar(int metodosDePagoId);
    }
}
