using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Pagos
{
    public class PagoEditDto
    {
        public int IdPago { get; set; }
        public int IdCliente { get; set; }
        public int IdMetodoPago { get; set; }
        public DateOnly Fecha { get; set; }
    }
}
