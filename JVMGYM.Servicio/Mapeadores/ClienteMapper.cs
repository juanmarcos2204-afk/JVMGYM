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
                FechaAlta = clienteCreateDto.FechaAlta,
                Activo = clienteCreateDto.Activo,
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
                FechaAlta = clienteEditDto.FechaAlta,
                Activo = clienteEditDto.Activo,
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
                FechaAlta = clientes.FechaAlta,
                Activo = clientes.Activo,
            };
        }
        public static ClienteCreateDto ToCreateDto(this ClienteEditDto clienteEditDto)
        {
            return new ClienteCreateDto
            {
                Nombre = clienteEditDto.Nombre,
                Apellido = clienteEditDto.Apellido,
                DNI = clienteEditDto.DNI,
                Telefono = clienteEditDto.Telefono,
                Domicilio = clienteEditDto.Domicilio,
                FechaAlta = DateOnly.FromDateTime(DateTime.Today),
                Activo = true
            };
        }
        public static ClienteEditDto ToEditDto (this Cliente cliente)
        {
            return new ClienteEditDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                DNI = cliente.DNI,
                Telefono = cliente.Telefono,
                Domicilio = cliente.Domicilio,
                FechaAlta = cliente.FechaAlta,
                Activo = cliente.Activo
            };
        }
    }
}
