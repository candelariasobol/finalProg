using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace parcialAPI.Models
{
    public partial class prog3Context : DbContext
    {
        public prog3Context()
        {
        }

        public prog3Context(DbContextOptions<prog3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Animale> Animales { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID= finalProg3; Password= finaLProg3DiC; Server=138.99.7.66; Database=prog3; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Animale>(entity =>
            {
                entity.ToTable("animales");

                entity.HasIndex(e => e.IdRaza, "fki_fk_raza");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.NombrePerro).IsRequired();

                entity.Property(e => e.NombreYapeDueno)
                    .IsRequired()
                    .HasColumnName("NombreYApeDueno");

                entity.Property(e => e.Telefono).IsRequired();

                entity.HasOne(d => d.IdRazaNavigation)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.IdRaza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_raza");
            });

            modelBuilder.Entity<Raza>(entity =>
            {
                entity.ToTable("razas");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
