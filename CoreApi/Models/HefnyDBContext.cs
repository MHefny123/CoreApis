using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApi.Models
{
       public partial class HefnyDBContext : DbContext
    {
        public HefnyDBContext()
        {
        }

        public HefnyDBContext(DbContextOptions<HefnyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dummies> Dummies { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Product> Product  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=HefnyDB;User Id=SA;Password=MHefny@550; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Dummies>(entity =>
            {
                entity.ToTable("DUMMIES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.EmpId);
                   // .HasName("PK__Employee__AF2DBA7997B2BD52");

                entity.Property(e => e.EmpId).HasColumnName("EmpID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender).HasMaxLength(10);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });


             modelBuilder.Entity<Product>(entity =>
            {

                entity.ToTable("Product");
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProdDesc).HasColumnName("proddesc");

                entity.Property(e => e.ProdName).HasColumnName("prodname");

                entity.Property(e => e.ProdPrice).HasColumnName("prodprice");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedat")
                    .HasColumnType("date");
            });
        }
    }
}

