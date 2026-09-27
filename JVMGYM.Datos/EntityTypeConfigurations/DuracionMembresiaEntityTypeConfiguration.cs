using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class DuracionMembresiaEntityTypeConfiguration : IEntityTypeConfiguration<DuracionesMembresias>
    {
        public void Configure(EntityTypeBuilder<DuracionesMembresias> builder)
        {
            builder.ToTable("DuracionesMembresias");
            builder.HasKey(dm => dm.IdDuracionMembresia);
        }
    }
}
