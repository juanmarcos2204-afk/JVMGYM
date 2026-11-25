using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Metodos_de_pago;
using JVMGYM.Servicio.Dtos.Pagos;

namespace JVMGYM.Servicio.Mapeadores
{
    public static class PagoMapper
    {
        public static Pago ToEntidad(this PagoCreateDto pagoCreateDto)
        {
            return new Pago
            {
                IdCliente = pagoCreateDto.IdCliente,
                IdMetodoPago = pagoCreateDto.IdMetodoPago,
                Fecha = DateOnly.FromDateTime(DateTime.Now)
            };
        }

        public static Pago ToEntidad(this PagoEditDto pagoEditDto)
        {
            return new Pago
            {
                IdPago = pagoEditDto.IdPago,
                IdCliente = pagoEditDto.IdCliente,
                IdMetodoPago = pagoEditDto.IdMetodoPago,
                Fecha = pagoEditDto.Fecha
            };
        }

        public static PagoListDto ToListDto(this Pago pago)
        {
            return new PagoListDto
            {
                IdPago = pago.IdPago,
                Fecha = pago.Fecha,
                Cliente = pago.Clientes is null
                    ? string.Empty
                    : $"{pago.Clientes.Nombre} {pago.Clientes.Apellido}".Trim(),
                MetodoPago = pago.MetodosDePago.Nombre
            };
        }

        public static PagoEditDto ToEditDto(this Pago pago)
        {
            return new PagoEditDto
            {
                IdPago = pago.IdPago,
                IdCliente = pago.IdCliente,
                IdMetodoPago = pago.IdMetodoPago,
                Fecha = pago.Fecha
            };
        }

        public static PagoCreateDto ToCreateDto(this PagoEditDto pagoEditDto)
        {
            return new PagoCreateDto
            {
                IdCliente = pagoEditDto.IdCliente,
                IdMetodoPago = pagoEditDto.IdMetodoPago
            };
        }
    }
}
