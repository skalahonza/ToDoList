using System.Reflection;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using ToDoList.BL.Validations;
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

// MongoDB
builder.Services.AddMongoDbImplementation(builder.Configuration);

// Postgres database
// builder.Services.AddPostgresImplementation(builder.Configuration);

var app = builder.Build();

// apply migrations to DB
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ToDoDbContext>();
    await context.Database.MigrateAsync();
}
*/

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