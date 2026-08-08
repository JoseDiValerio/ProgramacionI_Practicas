using Microsoft.EntityFrameworkCore;
using ProyectoReservasAulas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoReservasAulas.Data
{
    public class ControlReservasContext : DbContext
    {
        public DbSet<Aula> Aulas { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=DESKTOP-E9V3MBP\SQLEXPRESS;
                      Database=ControlReservasDB;
                      Trusted_Connection=True;
                      TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Aula -> Reserva
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Aula)
                .WithMany(a => a.Reservas)
                .HasForeignKey(r => r.AulaId);

            // Relación Profesor -> Reserva
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Profesor)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.ProfesorId);
        }
    }
}
