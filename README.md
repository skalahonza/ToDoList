# To Do List REST API
Simple To Do List REST API in .NET 6 and C# ♥. Database can be wither Postgres or MongoDb.

## How tu run
1. Run database(s)
`docker-compose up -d`
2. Run the app
    - Run with Postgres: `dotnet run -- postgres`
    - Run with MongoDb: `dotnet run -- mongo`
3. Go to https://localhost:7202/swagger and play ☻

## Project structure
### ToDoList.API
Rest API project. Contains controllers, configuration and Web server setup.

### ToDoList.BL
Business logic for To Do List. Contains interface definiton, DTOs and validation logic.

### ToDoList.EF
Implementation of To Do List using Entity Frmaework Core and PostgresSQL.

### ToDoList.Mongo
Implementation of To Do List using MongoDb.

## Postgres DB migrations
### Install tooling
`dotnet tool install --global dotnet-ef`
### Creating first migration
`dotnet ef migrations add Initial --startup-project ToDoList.API --project ToDoList.EF`

### Aplying migrations
App applies migrations during start.