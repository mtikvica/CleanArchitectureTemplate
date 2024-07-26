# Clean Architecture Solution Web API Template

## Description

This template provides a clean architecture solution for creating ASP.NET Core Web APIs with layers for Domain, Application, Infrastructure, and Web.API. It's designed to help you quickly get started with a robust and maintainable architecture.

## Requirements:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (latest version)

## Getting Started

- Install the Template

To install the template, run the following command:

```bash
dotnet new install tikvadev.CleanArchitecture.Template
```

## Create a New Project

Once the template is installed, create a new project using the template:

```bash
dotnet new cleanarch -n YourProjectName
```

This will create a new solution named YourProjectName with the following projects:

- YourProjectName.Domain

- YourProjectName.Application

- YourProjectName.Infrastructure

- YourProjectName.Web.API

## Launch the Application

Navigate to the Web.API project and run the application:

```bash
cd src/YourProjectName.Web.API
dotnet run
```

## Database

This solution is configured to use SQL Server.

## CI Pipeline

This template includes a CI pipeline for building the solution and running tests. You can integrate this pipeline preferred services like GitHub Actions or Azure Pipelines.

### Technologies Used

- [ASP.NET Core 8](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0)
- [EF Core 8](https://learn.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/)
- [xUnit](https://xunit.net/), [NSubstitute](https://nsubstitute.github.io/), [FluentAssertions](https://fluentassertions.com/)

### License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/mtikvica/CleanArchitectureTemplate/blob/main/LICENSE) file for details.
