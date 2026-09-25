using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.Repositorios
{
    public class PagosRepositorio : IPagosRepositorio
    {
        private readonly AppDbContext _context;
        public PagosRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Pagos pagos)
        {
            _context.Add(pagos);
            _context.SaveChanges();
        }

        public void Editar(Pagos pagos)
        {
            var pagosEnDb = _context.Pagos.Find(pagos.IdPago);
            if (pagosEnDb is null) throw new KeyNotFoundException($"No se encuentra un pago con ID: {pagos.IdPago}");
            pagosEnDb.IdCliente = pagos.IdCliente;
            pagosEnDb.IdMetodoPago = pagos.IdMetodoPago;
            pagosEnDb.Fecha = pagos.Fecha;

            _context.SaveChanges();
        }

        public void Eliminar(int pagosId)
        {
            var pagosEnDb = _context.Pagos.Find(pagosId);
            if (pagosEnDb is null) throw new KeyNotFoundException($"No se encuentra un pago con ID: {pagosId}");
            _context.Remove(pagosEnDb);
            _context.SaveChanges();
        }

        public Pagos? ObtenerPorId(int id)
        {
            return _context.Pagos
                    .FirstOrDefault(p => p.IdPago == id);

        }

        public List<Pagos> ObtenerTodos()
        {
            return _context.Pagos .ToList();
        }
    }
}
