using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class DuracionMembresiaEntityTypeConfiguration : IEntityTypeConfiguration<DuracioneMembresia>
    {
        public void Configure(EntityTypeBuilder<DuracioneMembresia> builder)
        {
            builder.ToTable("DuracionesMembresias");
            builder.HasKey(dm => dm.IdDuracionMembresia);
        }
    }
}
