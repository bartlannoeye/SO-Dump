# Reproduction steps

Question: http://stackoverflow.com/questions/37373322/cant-make-migration-uwp-sqlite-ef

- Create model
- Create DbContext
- Run following commands in the Nuget Package Manager

```
Install-Package Microsoft.EntityFrameworkCore.SQLite –Pre
Install-Package Microsoft.EntityFrameworkCore.Tools –Pre
Add-Migration MyFirstMigration
```
