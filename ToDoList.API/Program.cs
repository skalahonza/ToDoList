using System.Reflection;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.BL.Validations;
using ToDoList.EF;
using ToDoList.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Validation
builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateToDoListDtoValidator>();
    fv.ImplicitlyValidateChildProperties = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Generate swagger comments from summary
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddFluentValidationRulesToSwagger();

// lower case routes
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var mode = ParseMode(args);

switch (mode)
{
    case Mode.Postgres:
        Console.WriteLine(" === Running in Postgres mode. === ");
        builder.Services.AddPostgresImplementation(builder.Configuration);
        break;
    case Mode.MongoDb:
        Console.WriteLine(" === Running in MongoDb mode. === ");
        builder.Services.AddMongoDbImplementation(builder.Configuration);
        break;
}

var app = builder.Build();

if (mode == Mode.Postgres)
{
    // apply migrations to DB
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ToDoDbContext>();
    await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// For DEMO only
static Mode ParseMode(string[] args)
{
    return args switch
    {
        {Length: 0} => Mode.Postgres,
        {Length: 1} when args.Contains("postgres", StringComparer.OrdinalIgnoreCase) => Mode.Postgres,
        {Length: 1} when args.Contains("mongo", StringComparer.OrdinalIgnoreCase) => Mode.MongoDb,
        _ => throw new ArgumentException(
            "Only allowed parameters are none, postgres and mongo. e.g. 'dotnet run' or 'dotnet run -- mongo' or 'dotnet run postgres'")
    };
}

enum Mode
{
    Postgres,
    MongoDb
}