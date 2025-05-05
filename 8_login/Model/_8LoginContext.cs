using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _8_login.Model;

public partial class _8LoginContext : DbContext
{
    public _8LoginContext()
    {
    }

    public _8LoginContext(DbContextOptions<_8LoginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FullName> FullNames { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K4JARSC;Database=8_login;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FullName>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.ToTable("Full_name");

            entity.Property(e => e.FId)
                .ValueGeneratedNever()
                .HasColumnName("F_ID");
            entity.Property(e => e.FFirstName)
                .HasMaxLength(31)
                .HasColumnName("F_First_name");
            entity.Property(e => e.FLastName)
                .HasMaxLength(31)
                .HasColumnName("F_Last_name");
            entity.Property(e => e.FMiddleName)
                .HasMaxLength(31)
                .HasColumnName("F_Middle_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Role");

            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.RRole)
                .HasMaxLength(31)
                .HasColumnName("R_Role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId);

            entity.ToTable("User");

            entity.Property(e => e.UId)
                .ValueGeneratedNever()
                .HasColumnName("U_ID");
            entity.Property(e => e.UEmail)
                .HasMaxLength(255)
                .HasColumnName("U_Email");
            entity.Property(e => e.UFId).HasColumnName("U_F_ID");
            entity.Property(e => e.ULogin)
                .HasMaxLength(63)
                .IsFixedLength()
                .HasColumnName("U_Login");
            entity.Property(e => e.UPassword)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("U_Password");
            entity.Property(e => e.UPhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("U_Phone_Number");
            entity.Property(e => e.URId).HasColumnName("U_R_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
