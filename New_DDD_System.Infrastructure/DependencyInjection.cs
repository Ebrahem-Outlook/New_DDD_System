using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using New_DDD_System.Application.Core.Data;
using New_DDD_System.Domain.Users;
using New_DDD_System.Infrastructure.Database;
using New_DDD_System.Infrastructure.Repositories;

namespace New_DDD_System.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("ConnectionString can't be null or empty....");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        // register service inside the IOC container.

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
