using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class MembresiaEntityTypeConfiguration : IEntityTypeConfiguration<Membresias>
    {
        public void Configure(EntityTypeBuilder<Membresias> builder)
        {
            builder.ToTable("Membresias");
            builder.HasKey(m => m.IdMembresia);
        }
    }
}
