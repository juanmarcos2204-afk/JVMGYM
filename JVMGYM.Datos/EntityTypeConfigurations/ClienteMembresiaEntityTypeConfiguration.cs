using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMGYM.Datos.EntityTypeConfigurations
{
    public class ClienteMembresiaEntityTypeConfiguration : IEntityTypeConfiguration<ClientesMembresia>
    {
        public void Configure(EntityTypeBuilder<ClientesMembresia> builder)
        {
            builder.ToTable("ClientesMembresias");
            builder.HasKey(cm => cm.IdClienteMembresia);
        }
    }
}
