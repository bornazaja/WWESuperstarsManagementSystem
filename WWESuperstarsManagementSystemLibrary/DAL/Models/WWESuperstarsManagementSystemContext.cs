using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WWESuperstarsManagementSystemLibrary.DAL.Models
{
    public partial class WWESuperstarsManagementSystemContext : DbContext
    {
        public WWESuperstarsManagementSystemContext()
        {
        }

        public WWESuperstarsManagementSystemContext(DbContextOptions<WWESuperstarsManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Superstar> Superstars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=WWESuperstarsManagementSystem;User ID=sa;Password=SQL;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IDBrand)
                    .HasName("PK_IDBrand");

                entity.ToTable("Brand");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IDCity)
                    .HasName("PK_IDCity");

                entity.ToTable("City");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_IDCountry");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IDCountry)
                    .HasName("PK_IDCountry");

                entity.ToTable("Country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.IDGender)
                    .HasName("PK_IDGender");

                entity.ToTable("Gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Superstar>(entity =>
            {
                entity.HasKey(e => e.IDSuperstar)
                    .HasName("PK_IDSuperstar");

                entity.ToTable("Superstar");

                entity.Property(e => e.HeightCm).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WeightKg).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Superstars)
                    .HasForeignKey(d => d.BrandID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Superstar_IDBrand");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Superstars)
                    .HasForeignKey(d => d.CityID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Superstar_IDCity");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Superstars)
                    .HasForeignKey(d => d.GenderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Superstar_IDGender");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
