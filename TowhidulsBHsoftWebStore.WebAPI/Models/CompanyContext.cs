using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TowhidulsBHsoftWebStore.WebAPI.Models
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<BuyerRequestSubmission> BuyerRequestSubmission { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierProcessNpractice> SupplierProcessNpractice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK_Users");

                entity.Property(e => e.AdminId)
                    .HasColumnName("AdminID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Buyer)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Buyer_Company");
            });

            modelBuilder.Entity<BuyerRequestSubmission>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK_BuyerRequestSubmission");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ReuestDetails)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.BuyerRequestSubmission)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK_BuyerRequestSubmission2_Buyer");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Admin_Company");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK_Permissions");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("PermissionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BuyerNos).HasColumnName("BuyerNOS");

                entity.Property(e => e.SupplierNos).HasColumnName("SupplierNOS");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Permissions_Users");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SupplierID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SupplierProcessNpractice>(entity =>
            {
                entity.HasKey(e => e.ProcessId)
                    .HasName("PK_SupplierProcessNpractice");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.Practice)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProcessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierProcessNpractice)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierProcessNpractice2_Supplier");
            });
        }
    }
}
