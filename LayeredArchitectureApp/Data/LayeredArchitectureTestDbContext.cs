using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitectureApp.Data;

public partial class LayeredArchitectureTestDbContext : DbContext
{
    public LayeredArchitectureTestDbContext()
    {
    }

    public LayeredArchitectureTestDbContext(DbContextOptions<LayeredArchitectureTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=LayeredArchitectureTestDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC072BC86427");

            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
