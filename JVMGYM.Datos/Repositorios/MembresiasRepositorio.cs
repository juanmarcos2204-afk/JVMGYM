using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class MembresiasRepositorio:IMembresiasRepositorio
    {
        private readonly AppDbContext _context;
        public MembresiasRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Membresias membresias)
        {
            _context.Add(membresias);
            _context.SaveChanges();
        }

        public void Editar(Membresias membresias)
        {
            var membresiaEnDb = _context.Membresias.Find(membresias.IdMembresia);
            if (membresiaEnDb is null) throw new KeyNotFoundException($"No se encuentra un cliente con ID: {membresias.IdMembresia}");
            membresiaEnDb.Tipo = membresias.Tipo;
            membresiaEnDb.Precio = membresias.Precio;

            _context.SaveChanges();
        }

        public void Eliminar(int membresiaId)
        {
            var membresiaEnDb = _context.Membresias.Find(membresiaId);
            if (membresiaEnDb is null) throw new KeyNotFoundException($"No se encuentra un cliente con ID: {membresiaId}");
            _context.Membresias.Remove(membresiaEnDb);
            _context.SaveChanges();

        }

        public Membresias? ObtenerPorId(int id)
        {
            return _context.Membresias
                .FirstOrDefault(m => m.IdMembresia == id);
        }

        public List<Membresias> ObtenerTodos()
        {
            return _context.Membresias.ToList();
        }
    }
}
