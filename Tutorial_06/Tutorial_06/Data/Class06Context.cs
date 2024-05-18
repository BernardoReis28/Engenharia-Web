using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tutorial_06.Models;

namespace Tutorial_06.Data;

public partial class Class06Context : DbContext
{
    public Class06Context()
    {
    }

    public Class06Context(DbContextOptions<Class06Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("name=Class06Context");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Class>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__Class__3214EC0784455775");
    //    });

    //    modelBuilder.Entity<Student>(entity =>
    //    {
    //        entity.HasKey(e => e.Number).HasName("PK__Student__78A1A19CC8862743");

    //        entity.Property(e => e.Number).ValueGeneratedNever();

    //        entity.HasOne(d => d.Class).WithMany(p => p.Students).HasConstraintName("FK__Student__ClassId__267ABA7A");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
