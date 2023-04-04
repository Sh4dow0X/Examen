using System;
using System.Collections.Generic;
using APIPrueba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIPrueba.Dal
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descripcion> Descripcions { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Submarca> Submarcas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.ToTable("Descripcion");

                entity.Property(e => e.Descripcion1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion");

                entity.Property(e => e.DescripcionId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Descripcions)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__Descripci__IdMod__3E52440B");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSubmarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdSubmarca)
                    .HasConstraintName("FK__Modelo__IdSubmar__3B75D760");
            });

            modelBuilder.Entity<Submarca>(entity =>
            {
                entity.ToTable("Submarca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Submarcas)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Submarca__IdMarc__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
