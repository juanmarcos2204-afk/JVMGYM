using System;
using System.Collections.Generic;
using System.Text;
using JVMGYM.Entidades;
using Microsoft.EntityFrameworkCore;
namespace JVMGYM.Datos
{
    public class AppDbContext:DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Membresias> Membresias { get; set; }
        public DbSet<ClientesMembresia> ClientesMembresias { get; set; }
        public DbSet<MetodosDePago> MetodosDePagos { get; set; }
        public DbSet<DuracionesMembresias> DuracionesMembresias { get; set; }
        public DbSet<Pagos> Pagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JUAN;Database=JVMGYM;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
