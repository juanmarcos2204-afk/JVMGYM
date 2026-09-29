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
                IdDuracion = membresiaCreateDto.IdDuracion,
            };
        }

        public static Membresia ToEntidad(this MembresiaEditDto membresiaEditDto)
        {
            return new Membresia
            {
                IdMembresia = membresiaEditDto.IdMembresia,
                Tipo = membresiaEditDto.Tipo,
                Precio = membresiaEditDto.Precio,
                IdDuracion = membresiaEditDto.IdDuracion
            };
        }

        public static MembresiaListDto ToListDto(this Membresia membresia)
        {
            return new MembresiaListDto
            {
                IdMembresia = membresia.IdMembresia,
                Tipo = membresia.Tipo,
                Precio = membresia.Precio,
                IdDuracion = membresia.IdDuracion
            };
        }

    }
}
