using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class ClientesMembresiaRepositorio:IClientesMembresiaRepositorio
    {
        public List<ClientesMembresia> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.ClientesMembresias.ToList();
            }
        }
    }
}
