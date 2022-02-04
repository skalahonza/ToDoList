using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.BL;

namespace ToDoList.EF;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPostgresImplementation(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ToDoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ToDo")));
        services.AddScoped<ITodoService, ToDoService>();
        return services;
    }
}