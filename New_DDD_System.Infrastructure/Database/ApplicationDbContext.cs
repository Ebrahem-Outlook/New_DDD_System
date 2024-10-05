using Microsoft.EntityFrameworkCore;
using New_DDD_System.Application.Core.Data;
using New_DDD_System.Domain.Core.BaseType;
using System.Reflection;

namespace New_DDD_System.Infrastructure.Database;

public sealed class ApplicationDbContext : DbContext, IDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);   
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
