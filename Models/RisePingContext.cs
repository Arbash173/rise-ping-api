using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RisePingAPIs.Models;

public partial class RisePingContext : DbContext
{
    public RisePingContext()
    {
    }

    public RisePingContext(DbContextOptions<RisePingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptSetup> DeptSetups { get; set; }

    public virtual DbSet<EventRecord> EventRecords { get; set; }

    public virtual DbSet<NotificatoinType> NotificatoinTypes { get; set; }

    public virtual DbSet<RoleSetup> RoleSetups { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptSetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeptSetu__3214EC27034947BA");

            entity.ToTable("DeptSetup");

            entity.HasIndex(e => e.Name, "UQ__DeptSetu__737584F63A8C9AF1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EventRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventRec__3214EC2725F071CF");

            entity.HasIndex(e => e.Name, "UQ__EventRec__737584F6E30E35FD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTimeTo).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.EventRecords)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__EventReco__TypeI__60A75C0F");
        });

        modelBuilder.Entity<NotificatoinType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC2705AC243C");

            entity.HasIndex(e => e.Name, "UQ__Notifica__737584F6C6C90782").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoleSetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleSetu__3214EC272F2E55B2");

            entity.ToTable("RoleSetup");

            entity.HasIndex(e => e.Name, "UQ__RoleSetu__737584F6D021162E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27C177436B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534DA66362D").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F284560F159ACB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DeptId).HasColumnName("DeptID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmailInd).HasDefaultValue(true);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.InsertedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PushNotiInd).HasDefaultValue(true);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Score)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Users)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Users__DeptID__571DF1D5");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
