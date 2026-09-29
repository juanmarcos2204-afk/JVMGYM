using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class MembresiaEntityTypeConfiguration : IEntityTypeConfiguration<Membresia>
    {
        public void Configure(EntityTypeBuilder<Membresia> builder)
        {
            builder.ToTable("Membresias");
            builder.HasKey(m => m.IdMembresia);
            builder.HasOne(m => m.DuracionMembresia)
                .WithMany(p => p.Membresias)
                .HasForeignKey(m => m.IdDuracionMembresia)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
