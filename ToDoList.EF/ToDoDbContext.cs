using Microsoft.EntityFrameworkCore;
using ToDoList.EF.Entities;

namespace ToDoList.EF;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ToDoListEntity> Lists { get; set; }
    public DbSet<ToDoItemEntity> Items { get; set; }
}