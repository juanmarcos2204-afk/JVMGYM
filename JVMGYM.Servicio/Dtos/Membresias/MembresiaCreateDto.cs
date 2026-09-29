using JVMGYM.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JVMGYM.Servicio.Dtos.Membresias
{
    public class MembresiaCreateDto
    {
        public string Tipo { get; set; } = null!;
        public decimal Precio { get; set; }
        public int IdDuracionMembresia { get; set; }
    }
}
