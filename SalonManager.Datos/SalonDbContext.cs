using Microsoft.EntityFrameworkCore;
using SalonManager.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManager.Datos
{
    public class SalonDbContext : DbContext
    {
        public SalonDbContext(DbContextOptions<SalonDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estilista> Estilistas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<CitaServicio> CitaServicios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Comision> Comisiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave compuesta para la tabla intermedia
            modelBuilder.Entity<CitaServicio>()
                .HasKey(cs => new { cs.CitaId, cs.ServicioId });

            // Precisión para decimales
            modelBuilder.Entity<Servicio>()
                .Property(s => s.Precio).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<CitaServicio>()
                .Property(cs => cs.SubTotal).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Comision>()
                .Property(c => c.TotalComision).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.PrecioCompra).HasColumnType("decimal(10,2)");
        }
    }
}