using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
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

        public void Agregar(Membresia membresias)
        {
            _context.Add(membresias);
            _context.SaveChanges();
        }

        public void Editar(Membresia membresias)
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

        public Membresia? ObtenerPorId(int id)
        {
            return _context.Membresias
                .FirstOrDefault(m => m.IdMembresia == id);
        }

        public List<Membresia> ObtenerTodos()
        {
            return _context.Membresias
                .Include(m => m.DuracionMembresia)
                .ToList();
        }
    }
}
