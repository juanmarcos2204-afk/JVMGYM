using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class ClientesMembresiaRepositorio:IClientesMembresiaRepositorio
    {
        private readonly AppDbContext _context;
        public ClientesMembresiaRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public List<ClientesMembresia> ObtenerTodos()
        {
            return _context.ClientesMembresias.ToList();
        }
    }
}
