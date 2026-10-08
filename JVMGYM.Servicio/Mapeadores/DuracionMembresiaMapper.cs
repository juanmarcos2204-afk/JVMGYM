using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Duracion_Membresia;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Mapeadores
{
    public static class DuracionMembresiaMapper
    {
        public static DuracionMembresia ToEntidad(this DuracionMembresiaCreateDto duracionMembresiaCreateDto)
        {
            return new DuracionMembresia
            {
                Nombre = duracionMembresiaCreateDto.Nombre,
            };
        }
        public static DuracionMembresiaListDto ToListDto (this DuracionMembresia duracionMembresia)
        {
            return new DuracionMembresiaListDto
            {
                IdDuracionMembresia = duracionMembresia.IdDuracionMembresia,
                Nombre = duracionMembresia.Nombre,
            };
        }
    }
}
