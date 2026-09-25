using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class PagosRepositorio
    {
        private readonly AppDbContext _context;
        public PagosRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public List<Pagos> ObtenerTodos()
        {
            return _context.Pagos.ToList();
        }
    }
}
