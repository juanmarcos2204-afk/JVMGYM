using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class DuracionMembresiaRepositorio: IDuracionMembresiaRepositorio
    {
        private readonly AppDbContext _context;
        public DuracionMembresiaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(DuracionMembresia duracionMembresia)
        {
            _context.Add(duracionMembresia);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var duracionEnDb = _context.DuracionesMembresias.Find(id);
            if (duracionEnDb is null) throw new KeyNotFoundException($"No se encuentra una duración membresia con ID: {id}");
            _context.DuracionesMembresias.Remove(duracionEnDb);
            _context.SaveChanges();
        }

        public DuracionMembresia? ObtenerPorId(int id)
        {
            return _context.DuracionesMembresias
            .FirstOrDefault(d => d.IdDuracionMembresia == id);

        }

        public List<DuracionMembresia> ObtenerTodos()
        {
            return _context.DuracionesMembresias.ToList();
        }

        public bool TieneRegistrosRelacionados(int id)
        {
            return _context.Membresias.Any(m => m.IdDuracionMembresia == id);
        }
    }
}
