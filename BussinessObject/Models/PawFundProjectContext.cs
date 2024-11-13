using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessObject.Models;

public partial class PawFundProjectContext : DbContext
{
    public PawFundProjectContext()
    {
    }

    public PawFundProjectContext(DbContextOptions<Models.PawFundProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adoption> Adoptions { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:MyStockDB"];

        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adoption>(entity =>
        {
            entity.HasKey(e => e.AdoptionId).HasName("PK__Adoption__38BABF2CEB956C9A");

            entity.ToTable("Adoption");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reason).HasMaxLength(255);
            entity.Property(e => e.ReasonForAdopting)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SelfDescription)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Pet).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK__Adoption__PetId__3B75D760");

            entity.HasOne(d => d.User).WithMany(p => p.Adoptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Adoption__UserId__3C69FB99");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pet__48E538621F68A8AA");

            entity.ToTable("Pet");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Age).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalCondition)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PetName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PetType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Size).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Pets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Pet__UserId__3D5E1FD2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C463BB510");

            entity.ToTable("User");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
