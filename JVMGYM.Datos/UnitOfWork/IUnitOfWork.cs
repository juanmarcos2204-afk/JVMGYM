using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
