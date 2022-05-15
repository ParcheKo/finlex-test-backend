<div id="top"></div>

<h3 align="center">Sample ASP.NET WebAPI Project</h3>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#setup">Setup</a></li>
      </ul>
    </li>
    <li>
        <a href="#usage">Usage</a>
      <ul>
        <li><a href="#RESTful-API-collections">RESTful API collections</a></li>
      </ul>
    </li>
    <li>
        <a href="#contact">Contact</a>
    </li>
  </ol>
</details>

## About The Project

This is a sample project started for a simple task in a job interview process.

It tries to demo a very simple POC sales application.

It is based on Clean Architecture and also goes through the DDD (Domain-Driven Design) approach.
It uses a domain-centric design to model business concepts.
Unit tests for the business domain layer are included. 

It also implements a few practices being useful when going big and scale, 
both in domain logic and application load. Among them are :
* CQRS (Command Query Responsibility Segregation)
* Command
* Query
* Unit of Work
* Repository


### Built With

* .NET
* Entity Framework Core
* MediatR
* Autofac
* Serilog
* Swagger
* FluentValidation
* EFCore.NamingConventions
* Hellang.Middleware.ProblemDetails
* Humanizer.Core
* NUnit
* NSubstitute
* FluentAssertions


## Getting Started

Let's take it for a spin :-)

### Prerequisites

* .NET 6.0 SDK

    * Using PowerShell script from [here](https://dot.net/v1/dotnet-install.ps1).
    ```sh
    ./dotnet-install.ps1 -Runtime dotnet -Version 6.0.0
    ```

    * Using bash script from [here](https://dot.net/v1/dotnet-install.sh).
    ```sh
    ./dotnet-install.sh -Runtime dotnet -Version 6.0.0
    ```
  Or download the installation file for your OS from [Microsoft .NET downloads](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).


* An SQL Server Engine Instance. Some options are :
    * An MSSQLLocalDB instance used for development
    * Using Docker
  ```sh
  docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" `
   -p 1433:1433 --name sql1 --hostname sql1 `
   -d mcr.microsoft.com/mssql/server:2019-latest
  ```

* A MongoDB Server
    * Spin up a server simply using Docker :
  ```sh
  docker run --name some-mongo -d mongo:latest
  ```

* Entity Framework Core CLI
  ```sh
  dotnet tool install --global dotnet-ef
  ```

### Setup

1. Clone the repo
   ```sh
   git clone https://github.com/parcheko/finlex-test-backend
   ```

2. Restore Nuget packages
   ```sh
   dotnet restore ./src
   ```

3. Change database Connection Strings in appsettings.Development.json (if are different)
   ```json
   "ConnectionStrings": {
      ... 
        "SqlServerConnectionString": "Server=(localdb)\\mssqllocaldb;Database=WriteOrdersDb;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security=SSPI",
        "MongoConnectionString": "mongodb://localhost",
        "MongoDatabase": "ReadOrdersDb"
      ...
   }
   ```

4. Apply Entity Framework Core Migrations
   ```shell
   dotnet ef database update --startup-project orders.api --project orders.infrastructure
   ```

5. Start API
   ```shell
   dotnet run --project .\Orders.Api
   ```
API and swagger documentation can now be accessed on http://localhost:5101.

[//]: # (todo)
[//]: # (Setup using docker)
[//]: # (docker build -t finlex-task-orders-api:0.1.0 -f .\Orders.Api\Dockerfile .)

## Usage

### RESTful API collections

* orders
    * POST /orders
    * GET /orders

* persons
    * GET /persons/{email}/orders
    * GET /persons

## Contact

Amir A. Rezaei P. - [@amir_parcheko](https://twitter.com/amir_parcheko) - amir.a.rezaei.p@gmail.com

Project Link: [https://github.com/parcheko/finlex-test-backend](https://github.com/parcheko/finlex-test-backend)
