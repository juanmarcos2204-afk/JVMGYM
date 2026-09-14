using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class MembresiasRepositorio:IMembresiasRepositorio
    {
        public List<Membresias> ObtenerTodos()
        {
            using (var context = new AppDbContext())
            {
                return context.Membresias.ToList();
            }
        }
        public Membresias? ObtenerPorId(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Membresias.Find(id);
            }
        }
        public void Agregar(Membresias membresias)
        {
            using (var context = new AppDbContext())
            {
                context.Membresias.Add(membresias);
                context.SaveChanges();
            }
        }
        public void Actualizar(Membresias membresias)
        {
            using (var context = new AppDbContext())
            {
                context.Membresias.Update(membresias);
                context.SaveChanges();
            }
        }
        public void Editar(Membresias membresias)
        {
            using (var context = new AppDbContext())
            {
                context.Membresias.Update(membresias);
                context.SaveChanges();
            }
        }
        public void Eliminar(Membresias membresias)
        {
            using (var context = new AppDbContext())
            {
                context.Membresias.Remove(membresias);
                context.SaveChanges();   
            }
        }
    }
}
