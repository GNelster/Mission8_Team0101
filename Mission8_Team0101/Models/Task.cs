// Quadrant.cs
using System;
namespace Mission8_Team0101.Models;

public class Quadrant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}

// Category.cs
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Home, School, Work, Church
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}

// Task.cs
public class Task
{
    public int Id { get; set; }
    public string TaskName { get; set; } = string.Empty; // Required
    public DateTime? DueDate { get; set; }
    public int QuadrantId { get; set; }           // Required FK
    public Quadrant? Quadrant { get; set; }
    public int CategoryId { get; set; }           // Required FK
    public Category? Category { get; set; }
    public bool Completed { get; set; } = false;
}
