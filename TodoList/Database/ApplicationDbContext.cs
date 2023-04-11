using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Note> Notes { get; set; }

}