using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Pagos
{
    public class PagoCreateDto
    {
        public int IdCliente { get; set; }
        public int IdMetodoPago { get; set; }
    }
}
