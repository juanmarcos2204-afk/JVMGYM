using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class DuracionMembresiaEntityTypeConfiguration : IEntityTypeConfiguration<DuracionMembresia>
    {
        public void Configure(EntityTypeBuilder<DuracionMembresia> builder)
        {
            builder.ToTable("DuracionesMembresias");
            builder.HasKey(dm => dm.IdDuracionMembresia);
            builder.Property(dm => dm.Nombre).HasMaxLength(30);
        }
    }
}
