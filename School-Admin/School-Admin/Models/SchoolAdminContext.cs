using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School_Admin.Models
{
    public partial class SchoolAdminContext : DbContext
    {
        public SchoolAdminContext()
        {
        }

        public SchoolAdminContext(DbContextOptions<SchoolAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menumaster> Menumasters { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Rolemaster> Rolemasters { get; set; } = null!;
        public virtual DbSet<Rolemenumappingmaster> Rolemenumappingmasters { get; set; } = null!;
        public virtual DbSet<Roleusermappingmaster> Roleusermappingmasters { get; set; } = null!;
        public virtual DbSet<StudentMaster> StudentMasters { get; set; } = null!;
        public virtual DbSet<Usermaster> Usermasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6GDJH30P\\SQLEXPRESS; Database=SchoolAdmin; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menumaster>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__MENUMAST__C99ED250557E1C8D");

                entity.ToTable("MENUMASTER");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.TokenId)
                    .HasName("PK__RefreshT__658FEE8A63DAB6FC");

                entity.ToTable("RefreshToken");

                entity.Property(e => e.TokenId).HasColumnName("TokenID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.RefreshToken1).HasColumnName("RefreshToken");

                entity.Property(e => e.RefreshTokenCreatedTime).HasColumnType("datetime");

                entity.Property(e => e.RefreshTokenExpireTime).HasColumnType("datetime");

                entity.Property(e => e.Userid).HasColumnName("USerid");
            });

            modelBuilder.Entity<Rolemaster>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__ROLEMAST__8AFACE3AA510A6DB");

                entity.ToTable("ROLEMASTER");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rolemenumappingmaster>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__ROLEMENU__8B5781BD19AA9F43");

                entity.ToTable("ROLEMENUMAPPINGMASTER");

                entity.Property(e => e.MappingId).HasColumnName("MappingID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            modelBuilder.Entity<Roleusermappingmaster>(entity =>
            {
                entity.HasKey(e => e.MappingId)
                    .HasName("PK__ROLEUSER__8B5781BDE940C888");

                entity.ToTable("ROLEUSERMAPPINGMASTER");

                entity.Property(e => e.MappingId).HasColumnName("MappingID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<StudentMaster>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__StudentM__32C52A79B3702E5C");

                entity.ToTable("StudentMaster");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Isfee).HasColumnName("ISFee");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usermaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__USERMAST__7B4F2F5BE05B22A3");

                entity.ToTable("USERMASTER");

                entity.Property(e => e.UserId).HasColumnName("USerID");

                entity.Property(e => e.CreatedBy).HasColumnName("CreatedBY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.Iactive).HasColumnName("IActive");

                entity.Property(e => e.Islocked).HasColumnName("ISLocked");

                entity.Property(e => e.ModiFiedBy).HasColumnName("ModiFiedBY");

                entity.Property(e => e.ModiFiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USerName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
