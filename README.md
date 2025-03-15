├── .gitattributes
├── .gitignore
├── Management.Api
    ├── Controllers
    │   ├── CompaniesController.cs
    │   ├── EmployeesController.cs
    │   ├── UsersController.cs
    │   └── WeatherForecastController.cs
    ├── Management.Api.csproj
    ├── Management.Api.http
    ├── Middlewares
    │   └── ExceptionHandlingMiddleware.cs
    ├── Program.cs
    ├── Properties
    │   └── launchSettings.json
    ├── WeatherForecast.cs
    ├── appsettings.Development.json
    └── appsettings.json
├── Management.Application
    ├── Abstractions
    │   └── IApplicationDbContext.cs
    ├── ApplicationDependencyInjection.cs
    ├── Exceptions
    │   ├── BadRequestException.cs
    │   ├── NotFoundException.cs
    │   ├── ResourceNotFoundException.cs
    │   └── UnprocessableRequestException.cs
    ├── Management.Application.csproj
    ├── Models
    │   ├── ApiResult.cs
    │   ├── CompanyDto.cs
    │   ├── EmployeeDto.cs
    │   └── UserDto.cs
    ├── Password
    │   ├── IPasswordHasher.cs
    │   └── PasswordHasher.cs
    └── UseCases
    │   ├── CompanyCase
    │       ├── Commands
    │       │   ├── CreateCompanyCommand.cs
    │       │   ├── DeleteCompanyCommand.cs
    │       │   └── UpdateCompanyCommand.cs
    │       ├── Handlers
    │       │   ├── CommandsHandler
    │       │   │   ├── CreateCompanyHandler.cs
    │       │   │   ├── DeleteCompanyHandler.cs
    │       │   │   └── UpdateCompanyHandler.cs
    │       │   └── QueriesHandler
    │       │   │   ├── GetAllCompanyHandler.cs
    │       │   │   └── GetByIdCompanyHandler.cs
    │       └── Queries
    │       │   ├── GetAllCompanyQuery.cs
    │       │   └── GetByIdCompanyQuery.cs
    │   ├── EmployeeCase
    │       ├── Commands
    │       │   ├── CreateEmployeeCommand.cs
    │       │   ├── DeleteEmployeeCommand.cs
    │       │   └── UpdateEmployeeCommand.cs
    │       ├── Handlers
    │       │   ├── CommandsHandler
    │       │   │   ├── CreateEmployeeHandler.cs
    │       │   │   ├── DeleteEmployeeHandler.cs
    │       │   │   └── UpdateEmployeeHandler.cs
    │       │   └── QueriesHandler
    │       │   │   ├── GetAllEmployeeHandler.cs
    │       │   │   └── GetByIdEmployeeHandler.cs
    │       └── Queries
    │       │   ├── GetAllEmployeeQuery.cs
    │       │   └── GetByIdEmployeeQuery.cs
    │   └── UserCase
    │       ├── Commands
    │           ├── CreateUserCommand.cs
    │           ├── DeleteUserCommand.cs
    │           └── UpdateUserCommand.cs
    │       ├── Handlers
    │           ├── CommandsHandler
    │           │   ├── CreateUserHandler.cs
    │           │   ├── DeleteUserHandler.cs
    │           │   └── UpdateUserHandler.cs
    │           └── QueriesHandler
    │           │   ├── GetAllUserHandler.cs
    │           │   └── GetByIdUserHandler.cs
    │       └── Queries
    │           ├── GetAllUserQuery.cs
    │           └── GetByIdUserQuery.cs
├── Management.Core
    ├── Entities
    │   ├── Company.cs
    │   ├── Employee.cs
    │   └── User.cs
    ├── Enums
    │   └── Role.cs
    └── Management.Domain.csproj
├── Management.sln
└── Mangement.Infrastructure
    ├── InfrastructureDependencyInjection.cs
    ├── Mangement.Infrastructure.csproj
    ├── Migrations
        ├── 20241222181056_AddNullable.Designer.cs
        └── 20241222181056_AddNullable.cs
    └── Persistence
        ├── ApplicationDbContext.cs
        ├── Configurations
            ├── CompanyConfiguration.cs
            ├── EmployeeConfiguration.cs
            └── UserConfiguration.cs
        └── Migrations
            ├── 20241221215436_init.Designer.cs
            ├── 20241221215436_init.cs
            └── ApplicationDbContextModelSnapshot.cs
