using JVMGYM.Datos.Interfaces;
using JVMGYM.Entidades;

namespace JVMGYM.Datos.Repositorios
{
    public class MetodosDePagoRepositorio : Repositorio<MetodosDePago>, IMetodosDePagoRepositorio
    {
        public MetodosDePagoRepositorio(AppDbContext context) : base(context)
        {
        }

        public bool Existe(MetodosDePago metodosDePago)
        {
            return _context.MetodosDePagos.Any(m => m.Nombre == metodosDePago.Nombre &&
                m.IdMetodoPago != metodosDePago.IdMetodoPago);
        }

        public bool TieneRegistrosRelacionados(int id)
        {
            return _context.Pagos.Any(p => p.IdMetodoPago == id);
        }
    }
}
