using JVMGYM.Entidades;

namespace JVMGYM.Servicio.Dtos.Membresias
{
    public class MembresiaEditDto
    {
        public int IdMembresia { get; set; }
        public string Tipo { get; set; } = null!;
        public decimal Precio { get; set; }
        public int IdDuracionMembresia { get; set; }
    }
}
