# Clothing Store Management Application

This application is a CRUD system for managing Clothing Stores and their products.

The project includes a REST API, a Web application, and unit tests, all within the same Visual Studio solution.

It has been developed following best practices such as layered architecture, dependency injection, SOLID principles, and validations.

## Demo

Video demonstration of the Web: [See video](https://www.youtube.com/watch?v=-Qrwt2zqLuU).
Video demonstration of the Api: [See video](https://www.youtube.com/watch?v=nCMCeEjawa8).

## Tech

- **Microsoft Visual Studio Community 2022 (64-bit)** - Version 17.10.1

- **.NET 8.0**

- **SQL Server Management Studio** - Version 20.1.10.0

## Setup

1.  **Create a database in SQL Server** using the `SQL-CreateDatabaseScript.sql` script.

2.  **Change the server name in:**

- `..\OnlineShop-CRUD-NetCore8\OnlineShop.Api\appsettings.json`

- `..\OnlineShop-CRUD-NetCore8\OnlineShop.Web\appsettings.json`

3.  **Set multiple project startup** in the solution properties:

- `OnlineShop.Api -> Start`

- `OnlineShop.Web -> Start`

4.  **Run** the solution.

## Database Schema

### Stores

| Column   | Data Type    | Constraints           |
| -------- | ------------ | --------------------- |
| id       | INT IDENTITY | PRIMARY KEY, NOT NULL |
| name     | VARCHAR(100) | NOT NULL              |
| location | VARCHAR(100) | NOT NULL              |

### Products

| Column      | Data Type    | Constraints           |
| ----------- | ------------ | --------------------- |
| id          | INT IDENTITY | PRIMARY KEY, NOT NULL |
| name        | VARCHAR(100) | NOT NULL              |
| size        | VARCHAR(50)  | NOT NULL              |
| color       | VARCHAR(50)  | NOT NULL              |
| price       | VARCHAR(50)  | NOT NULL              |
| description | VARCHAR(50)  | NULL                  |

### StoreProducts

| Column    | Data Type | Constraints                                   |
| --------- | --------- | --------------------------------------------- |
| StoreId   | INT       | NOT NULL, FOREIGN KEY REFERENCES Stores(id)   |
| ProductId | INT       | NOT NULL, FOREIGN KEY REFERENCES Products(id) |
| stock     | INT       | NOT NULL                                      |
|           |           | PRIMARY KEY (StoreId, ProductId)              |
