using LearningCenterAPI.Learning.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterAPI.Learning.Persistance.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Category>Categories { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder Builder)
    {
        base.OnModelCreating(Builder);

        Builder.Entity<Category>().ToTable("Categories");
        Builder.Entity<Category>().HasKey(p => p.Id);
        Builder.Entity<Category>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        Builder.Entity<Category>().Property(p=>p.Name).IsRequired().HasMaxLength(30);


    }
}