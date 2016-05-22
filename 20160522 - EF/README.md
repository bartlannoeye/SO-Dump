# Reproduction steps

- Create model
- Create DbContext
- Run following commands in the Nuget Package Manager

Install-Package Microsoft.EntityFrameworkCore.SQLite –Pre
Install-Package Microsoft.EntityFrameworkCore.Tools –Pre
Add-Migration MyFirstMigration