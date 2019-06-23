using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TiendeoApi.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Negocio> Negocio { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<TipoServicio> TipoServicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PK__Ciudad__D4D3CCB017A9CBC4");

                entity.HasIndex(e => new { e.Nombre, e.Provincia })
                    .HasName("AK_nombre_provincia")
                    .IsUnique();

                entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal)
                    .HasName("PK__Local__C287B9BBCACD8FE4");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Local__IdCiudad__61BB7BD9");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Local)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Local__IdNegocio__62AFA012");
            });

            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.HasKey(e => e.IdNegocio)
                    .HasName("PK__Negocio__750B6A559C6EB8A5");

                entity.Property(e => e.Marker)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__2DCCF9A2D315818C");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Servicio__IdLoca__6774552F");

                entity.HasOne(d => d.IdTipoServicioNavigation)
                    .WithMany(p => p.Servicio)
                    .HasForeignKey(d => d.IdTipoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Servicio__IdTipo__68687968");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK__Tienda__5A1EB96B023F4289");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Tienda)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tienda__IdLocal__6E2152BE");
            });

            modelBuilder.Entity<TipoServicio>(entity =>
            {
                entity.HasKey(e => e.IdTipoServicio)
                    .HasName("PK__TipoServ__E29B3EA7B2BC3099");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
