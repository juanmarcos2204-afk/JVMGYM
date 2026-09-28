using JVMGYM.Entidades;
using JVMGYM.Servicio.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Servicio.Mapeadores
{
    public static class ClienteMapper
    {
        public static Cliente ToEntidad(this ClienteCreateDto clienteCreateDto)
        {
            return new Cliente
            {
                Nombre = clienteCreateDto.Nombre,
                Apellido = clienteCreateDto.Apellido,
                DNI = clienteCreateDto.DNI,
                Telefono = clienteCreateDto.Telefono,
                Domicilio = clienteCreateDto.Domicilio,
                FechaAlta = clienteCreateDto.FechaAlta
            };
        }
        public static Cliente ToEntidad(this ClienteEditDto clienteEditDto)
        {
            return new Cliente
            {
                IdCliente = clienteEditDto.IdCliente,
                Nombre = clienteEditDto.Nombre,
                Apellido = clienteEditDto.Apellido,
                DNI = clienteEditDto.DNI,
                Telefono = clienteEditDto.Telefono,
                Domicilio = clienteEditDto.Domicilio,
                FechaAlta = clienteEditDto.FechaAlta
            };
        }
        public static ClientesListDto ToListDto(this Cliente clientes)
        {
            return new ClientesListDto
            {
                IdCliente = clientes.IdCliente,
                Nombre = clientes.Nombre,
                Apellido = clientes.Apellido,
                DNI = clientes.DNI,
                Telefono = clientes.Telefono,
                Domicilio = clientes.Domicilio,
                FechaAlta = clientes.FechaAlta

            };
        }
    }
}
