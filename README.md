## Introduction

Simple solution to creating a REST API to manage products catalog.

### Tools/Frameworks
- .NET 5
- EntityFrameworkCore
- SQL Server 
- Swagger

### How to run
- Update connection string in `appsettings.json`

- Create and seed the database by running following command from `Synda.Api` directory
```
dotnet ef database update -p ..\Synda.Data
```

- Set `Synda.Api` as startup project
- Run project from Visual Studio