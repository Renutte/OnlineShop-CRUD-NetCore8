### Tools:

- **Microsoft Visual Studio Community 2022 (64-bit)** - Version 17.10.1
- **.NET 8.0**
- **SQL Server Management Studio** - Version 20.1.10.0

### Setup:

1.  **Create a database in SQL Server** using the "SQL-CreateDatabaseScript.sql" script.
2.  **Change the server name in:**
    - `..\OnlineShop-CRUD-NetCore8\OnlineShop.Api\appsettings.json`
    - `..\OnlineShop-CRUD-NetCore8\OnlineShop.Web\appsettings.json`
3.  **Set multiple project startup** in the solution properties.
    - `OnlineShop.Api -> Start`
    - `OnlineShop.Web -> Start`
4.  **Run** solution.
