using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using New_DDD_System.Application.Core.Data;
using New_DDD_System.Domain.Users;
using New_DDD_System.Domain.Users.ValueObjects;
using System.Linq;

namespace New_DDD_System.Infrastructure.Repositories;

internal sealed class UserRepository(IDbContext dbContext) : IUserRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<User>().AddAsync(user, cancellationToken);
    }

    public void Update(User user)
    {
        dbContext.Set<User>().Update(user);
    }

    public void Delete(User user)
    {
        dbContext.Set<User>().Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .AsNoTracking()
                              .Take(10)
                              .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .AsNoTracking()
                              .SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .AsNoTracking()
                              .SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetUserByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
                              .AsNoTracking()
                              .Where(user => user.FirstName.Contains(name))
                              .ToListAsync(cancellationToken);
    }
}
