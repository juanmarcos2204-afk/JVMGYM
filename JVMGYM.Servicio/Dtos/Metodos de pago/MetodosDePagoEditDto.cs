using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Metodos_de_pago
{
    public class MetodosDePagoEditDto
    {
        public int idMetodoPago { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
