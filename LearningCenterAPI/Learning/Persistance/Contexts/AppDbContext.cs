using LearningCenterAPI.Learning.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCenterAPI.Learning.Persistance.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tutorial>Tutorials { get; set; }
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

        //relationships
        Builder.Entity<Category>()
            .HasMany(p => p.Tutorials)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CatergoryId);
            

        Builder.Entity<Tutorial>().ToTable("Tutorials");
        Builder.Entity<Tutorial>().HasKey(p => p.Id);
        Builder.Entity<Tutorial>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        Builder.Entity<Tutorial>().Property(p=>p.Title).IsRequired().HasMaxLength(30);
        Builder.Entity<Tutorial>().Property(p=>p.Description).IsRequired().HasMaxLength(300);
        
        
        
    }
    
    
    
}