using AutoMapper;
using AutoMapper.QueryableExtensions;
using MongoDB.Driver.Linq;

namespace ToDoList.Mongo.Extensions;

public static class MongoDbExtensions
{
    public static IMongoQueryable<TDestination> MapTo<TDestination>(this IMongoQueryable source, IMapper mapper) =>
        (IMongoQueryable<TDestination>) source.ProjectTo<TDestination>(mapper.ConfigurationProvider);
}