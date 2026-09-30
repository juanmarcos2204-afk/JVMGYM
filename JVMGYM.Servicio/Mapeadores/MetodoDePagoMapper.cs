using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Mapeadores
{
    public static class MetodoDePagoMapper
    {
        public static MetodosDePago ToEntidad(this MetodosDePagoCreateDto metodoDePagoCreateDto)
        {
            return new MetodosDePago
            {
                Nombre = metodoDePagoCreateDto.Nombre,
            };
        }
        public static MetodosDePago ToEntidad(this MetodosDePagoEditDto metodoDePagoEditDto)
        {
            return new MetodosDePago
            {
                IdMetodoPago = metodoDePagoEditDto.idMetodoPago,
                Nombre = metodoDePagoEditDto.Nombre
            };
        }

        public static MetodoDePagoListDto ToListDto(this MetodosDePago metodosDePago)
        {
            return new MetodoDePagoListDto
            {
                IdMetodoPago = metodosDePago.IdMetodoPago,
                Nombre = metodosDePago.Nombre
            };
        }

    }
}
