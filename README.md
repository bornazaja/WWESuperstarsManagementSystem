# WWE Superstars Management System
WWE Superstars Management System is application that has REST API service on which you can send and retreive data.

For simplicity of the project .NET Core console app is used for client with dependency injection (DI).

### Tehnologies
* ASP.NET Core API
* Entity Framework Core
* MS SQL Server
* AutoMapper

### Requirements
* Installed Visual Studio 2012 or higher
* Installed MS SQL Server 2012 or higher
* Installed MS SQL Management Studio 2012 or higher

### Instructions
* Clone or download and unzip project
* Clean and rebuild solution
* Run SQL script in MS SQL Management Studio which is located in folder `WWESuperstarsManagementSystem/WWESuperstarsManagementSystemLibrary/sql/WWESuperstarsManagementSystemScript.sql`
* As needed in project `WWESuperstarsManagementSystemLibrary` change connection string in namespace `WWESuperstarsManagementSystemLibrary/DAL/Models` in class `WWESuperstarsManagementSystemContext.cs` in method `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)`
* Run `WWESuperstarsManagementSystemAPI`
* Run `WWESuperstarsManagementSystemConsole`