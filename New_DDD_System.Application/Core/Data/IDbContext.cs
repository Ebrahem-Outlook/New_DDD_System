using Microsoft.EntityFrameworkCore;
using New_DDD_System.Domain.Core.BaseType;

namespace New_DDD_System.Application.Core.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
