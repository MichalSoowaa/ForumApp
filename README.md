ASP .NET CORE MVC, Entity Framework, MSSQL, CQRS, FluentValidation, MediatR

Forum web app

# How to run
Requirements: .NET8, SQL Server, Visual Studio (or just Entity Framework)

Configure database connection string in appsettings.json.

If you use Visual Studio, open NuGet Package Manager Console, set project to Forum.Web and type command:
`Update-Database`
and run the application.

If you do not use Visual Studio, type commands:
```bash 
dotnet restore
dotnet ef database update
dotnet run
```
