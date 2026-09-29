using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class MetodosDePagoEntityTypeConfiguration : IEntityTypeConfiguration<MetodosDePago>
    {
        public void Configure(EntityTypeBuilder<MetodosDePago> builder)
        {
            builder.ToTable("MetodosDePago");
            builder.HasKey(mp => mp.IdMetodoPago);
        }
    }
}
