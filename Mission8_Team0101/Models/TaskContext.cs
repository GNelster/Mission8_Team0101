
// AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using Task = Mission8_Team0101.Models.Task;
namespace Mission8_Team0101.Models;

public class TaskContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Quadrant> Quadrants { get; set; }
    public DbSet<Category> Categories { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Category dropdown options
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Home" },
            new Category { Id = 2, Name = "School" },
            new Category { Id = 3, Name = "Work" },
            new Category { Id = 4, Name = "Church" }
        );

        // Seed Quadrant options (Steven Covey Time Management Matrix)
        modelBuilder.Entity<Quadrant>().HasData(
            new Quadrant { Id = 1, Name = "Q1 - Urgent & Important" },
            new Quadrant { Id = 2, Name = "Q2 - Not Urgent & Important" },
            new Quadrant { Id = 3, Name = "Q3 - Urgent & Not Important" },
            new Quadrant { Id = 4, Name = "Q4 - Not Urgent & Not Important" }
        );

        // Enforce required fields
        modelBuilder.Entity<Task>()
            .Property(t => t.TaskName).IsRequired();

        modelBuilder.Entity<Task>()
            .HasOne(t => t.Quadrant)
            .WithMany(q => q.Tasks)
            .HasForeignKey(t => t.QuadrantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Task>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
