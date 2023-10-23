using System;
using System.Collections.Generic;
using FinalProjectWebAPI.DomainModels.ProductChildClasses;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWebAPI.Model;

public partial class SellingDbContext : DbContext
{
    public SellingDbContext()
    {
    }

    public SellingDbContext(DbContextOptions<SellingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; }

    public virtual DbSet<CustomersRelationship> CustomersRelationships { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PhoneType> PhoneTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Toy> Toys { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<SportInventory> SportInventories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\SabaPC;Database=SellingDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Adress)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.GenderId).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Pn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PN");
        });

        modelBuilder.Entity<CustomersPhoneNumber>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsMain)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomersRelationship>(entity =>
        {
            entity.Property(e => e.Comment)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderDate).HasColumnType("date");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PhoneType>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<RelationshipType>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CompanyFullName)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.CompanyName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ShortName)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.DocNumber)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.OperationDate).HasColumnType("date");
            entity.Property(e => e.RealizationPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Unit).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouse_Units");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
