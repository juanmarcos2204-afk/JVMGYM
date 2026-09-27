using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class PagoEntityTypeConfiguration : IEntityTypeConfiguration<Pagos>
    {
        public void Configure(EntityTypeBuilder<Pagos> builder)
        {
            builder.ToTable("Pagos");
            builder.HasKey(p => p.IdPago);
        }
    }
}
