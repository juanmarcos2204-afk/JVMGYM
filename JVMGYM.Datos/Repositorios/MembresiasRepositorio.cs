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
        public List<Membresias> ObtenerTodos()
        {
            return _context.Membresias.ToList();
        }
        public Membresias? ObtenerPorId(int id)
        {
            return _context.Membresias.Find(id);
        }
        public void Agregar(Membresias membresias)
        {
            _context.Membresias.Add(membresias);
            _context.SaveChanges();
        }
        public void Editar(Membresias membresias)
        {
            _context.Membresias.Update(membresias);
            _context.SaveChanges();
        }
        public void Eliminar(Membresias membresias)
        {
            _context.Membresias.Remove(membresias);
            _context.SaveChanges();
        }
    }
}
