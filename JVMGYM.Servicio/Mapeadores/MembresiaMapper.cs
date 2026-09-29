using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using JVMGYM.Servicio.Dtos.Membresias;

namespace JVMGYM.Servicio.Mapeadores
{
    public static class MembresiaMapper
    {
        public static Membresia ToEntidad(this MembresiaCreateDto membresiaCreateDto)
        {
            return new Membresia
            {
                Tipo = membresiaCreateDto.Tipo,
                Precio = membresiaCreateDto.Precio,
                IdDuracionMembresia = membresiaCreateDto.IdDuracionMembresia
            };
        }

        public static Membresia ToEntidad(this MembresiaEditDto membresiaEditDto)
        {
            return new Membresia
            {
                IdMembresia = membresiaEditDto.IdMembresia,
                Tipo = membresiaEditDto.Tipo,
                Precio = membresiaEditDto.Precio,
                IdDuracionMembresia = membresiaEditDto.IdDuracionMembresia,
            };
        }

        public static MembresiaListDto ToListDto(this Membresia membresia)
        {
            return new MembresiaListDto
            {
                IdMembresia = membresia.IdMembresia,
                Tipo = membresia.Tipo,
                Precio = membresia.Precio,
                DuracionMembresia = membresia.DuracionMembresia!.Nombre
            };
        }

    }
}
