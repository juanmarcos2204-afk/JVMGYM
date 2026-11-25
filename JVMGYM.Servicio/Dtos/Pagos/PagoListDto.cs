using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Pagos
{
    public class PagoListDto
    {
        public int IdPago { get; set; }
        public DateOnly Fecha { get; set; }
        public string Cliente { get; set; } = null!;
        public string MetodoPago { get; set; } = null!;
    }
}
