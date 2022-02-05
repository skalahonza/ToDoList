using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ToDoList.BL;

namespace ToDoList.Mongo.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddMongoDbImplementation(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient, MongoClient>(x =>
            new MongoClient(configuration.GetConnectionString("ToDoMongo")));
        services.AddScoped<ToDoMongoDbContext>();
        services.AddScoped<ITodoService, ToDoService>();
        return services;
    }
}