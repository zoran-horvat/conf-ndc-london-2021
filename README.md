# NDC London 2021: Securing Multitenant Databases with Entity Framework Core

Demos were developed using Visual Studio 2019. These are prerequisites to build and run demos:
  - .NET Core 3.1
  - Database server - By default, application will connect to MS SQL LocalDB provider; if other provider is to be used, please modify connection string in [Startup.cs](https://github.com/zoran-horvat/conf-ndc-london-2021/blob/master/01%20Initial/Demo/Startup.cs "Startup.cs")

Before running demos, please refresh the database by dropping it and updating again:

    Drop-Database -context EntireContext
    Update-Database -context EntireContext
    
This will ensure that all seed data are present which are required to demonstrate security concepts.
