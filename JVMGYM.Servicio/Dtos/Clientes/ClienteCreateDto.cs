using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Clientes
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Domicilio { get; set; } = null!;
        public DateOnly FechaAlta { get; set; }
    }
}
