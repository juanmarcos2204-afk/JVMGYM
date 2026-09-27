using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.Nombre).HasMaxLength(50);
            builder.Property(c => c.Apellido).HasMaxLength(50);
            builder.Property(c => c.DNI).HasMaxLength(10);
            builder.Property(c => c.Apellido).HasMaxLength(50);
            builder.Property(c => c.Telefono).HasMaxLength(30);
            builder.Property(c => c.Domicilio).HasMaxLength(30);
            builder.Property(c => c.FechaAlta);
        }
    }
}
