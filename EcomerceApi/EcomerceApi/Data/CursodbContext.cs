using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcomerceApi.Data
{
    public partial class CursodbContext : DbContext
    {
        public CursodbContext()
        {
        }

        public CursodbContext(DbContextOptions<CursodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Carro> Carros { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<MedioPago> MedioPagos { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:cursoserverfjq.database.windows.net,1433;Initial Catalog=cursodb;Persist Security Info=False;User ID=fjimenezq;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UrlImagen).HasMaxLength(50);

                entity.Property(e => e.Valor).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Carro>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.Carros)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carros_Articulos");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("Inventario");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Inventario)
                    .HasForeignKey<Inventario>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_ToTable");
            });

            modelBuilder.Entity<MedioPago>(entity =>
            {
                entity.ToTable("MedioPago");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroTarjeta).HasColumnType("numeric(16, 0)");

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Vencimiento)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Orden>(entity =>
            {                
              entity.Property(e => e.Id).ValueGeneratedOnAdd();

              entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Factura)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Monto).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordenes_Articulos");

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithMany(p => p.Ordenes)
                    .HasForeignKey(d => d.IdPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordenes_MediosPago");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
