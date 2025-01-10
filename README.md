# Hydra

##  Modular Monolith Clean Architecture with ASP.NET 8

This project implements a modular monolith architecture with clean architecture principles using ASP.NET 8.

### Features

* **Modular Design:** The application is split into modules, each representing a functional area of the application. This promotes loose coupling and improves maintainability.
* **Clean Architecture:** The application adheres to the clean architecture principles, separating concerns between the user interface (UI), business logic (core), and data access (infrastructure).
* **Entity Framework Core with Automatic Configuration:** Entity Framework Core is used for data access with automatic entity configuration, allowing modules to define their entities without manual configuration.
* **Second-Level Caching:** Automatic second-level caching is implemented for queries with support for multiple cache providers like InMemory and Redis, improving performance.
* **Dynamic Permissions:** Security features are implemented with dynamic permissions, allowing for fine-grained access control.
* **Serilog Logging:** Serilog is used for logging with support for multiple storage options like files, SQLite, and Elasticsearch.
* **Centralized Configuration Management:** Application settings and configurations are managed centrally for easy maintenance.
* **Scheduled Jobs:** The application supports scheduling jobs for background tasks.

### Getting Started

1. Clone the repository:

```bash
git clone https://github.com/your-username/your-repo-name.git
```

2. Restore NuGet packages:

```bash
cd your-repo-name
dotnet restore
```

3. Run the application:

```bash
dotnet run
```

### Project Structure

The project is structured with the following folders:

* **Core:** This folder contains the core application logic, including entities, interfaces, and application services.
* **Modules:** This folder contains individual modules, each with its own controllers, repositories, and business logic specific to the module's functionality.
* **Infrastructure:** This folder contains infrastructure code, such as database access with Entity Framework Core and logging configuration with Serilog.
* **API:** This folder (optional) can contain the ASP.NET Core API controllers for the application.
* **Startup.cs:** This file configures the application services and middleware.

### Module Development

* Create a new folder within the Modules directory for your new module.
* Define your module's entities within the module folder.
* Implement repositories and business logic specific to your module.
* Register your module's services in the Startup.cs file.

### Documentation

* More detailed documentation for specific features will be added to the respective folders.

### Contribution

We welcome contributions to this project.
