using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Todo.Context;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {}

    public DbSet<Domain.Todo.Todo> Todos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
    }
    
}