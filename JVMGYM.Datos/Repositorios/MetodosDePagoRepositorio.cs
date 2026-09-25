using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio
    {
        private readonly AppDbContext _context;
        public MetodosDePagoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public void Agregar(MetodosDePago metodosDePago)
        {
            _context.Add(metodosDePago);
            _context.SaveChanges();
        }

        public void Editar(MetodosDePago metodosDePago)
        {
            var metodosDePagoEnDb = _context.MetodosDePagos.Find(metodosDePago.IdMetodoPago);
            if (metodosDePagoEnDb is null) throw new KeyNotFoundException($"No se encuentra un metodo de pago con ID: {metodosDePago.IdMetodoPago}");
            metodosDePagoEnDb.Nombre = metodosDePago.Nombre;

            _context.SaveChanges();
        }

        public void Eliminar(int metodoDePagoId)
        {
            var metodosDePagoEnDb = _context.MetodosDePagos.Find(metodoDePagoId);
            if (metodosDePagoEnDb is null) throw new KeyNotFoundException($"No se encuentra un metodo de pago con ID: {metodoDePagoId}");
            _context.MetodosDePagos.Remove(metodosDePagoEnDb);
            _context.SaveChanges();

        }

        public MetodosDePago? ObtenerPorId(int id)
        {
            return _context.MetodosDePagos
                .FirstOrDefault(mp => mp.IdMetodoPago == id);
        }

        public List<MetodosDePago> ObtenerTodos()
        {
            return _context.MetodosDePagos.ToList();
        }
    }

}
