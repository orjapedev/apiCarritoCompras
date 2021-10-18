using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace apiCarritoCompras.Model
{
    public partial class cartshopContext : DbContext
    {
        public cartshopContext()
        {
        }

        public cartshopContext(DbContextOptions<cartshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<PlanesProducto> PlanesProductos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-19F5RBB\\SQLEXPRESS;Database=cartshop;user=sa;password=barcelona");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.IdPlan)
                    .HasName("PK__Planes__FB8102AECEAAF02E");

                entity.Property(e => e.Codigo)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Frecuencia)
                    .IsUnicode(false)
                    .HasColumnName("frecuencia");

                entity.Property(e => e.Icono)
                    .IsUnicode(false)
                    .HasColumnName("icono");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<PlanesProducto>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdPlan).HasColumnName("idPlan");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdPlanNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPlan)
                    .HasConstraintName("FK__PlanesPro__idPro__52593CB8");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__PlanesPro__idPro__534D60F1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Detalle)
                    .IsUnicode(false)
                    .HasColumnName("detalle");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Usuarios__AB6E6165B63EC561");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Clave)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PlanId).HasColumnName("planId");

                entity.Property(e => e.Telefono)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK__Usuarios__planId__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
