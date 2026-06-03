# EmployeeManagementSystem

## Projects

- `EmployeeManagementSystem.API`
  - `Controllers/`
    - `EmployeeController.cs`
  - `appsettings.json`
  - `Program.cs`
  - `EmployeeManagementSystem.API.http`

- `EmployeeManagementSystem.Application`
  - `Service/`
    - `EmpService.cs`
  - `DTOs/`
    - `CreateDto.cs`
    - `UpdateDto.cs`
    - `ResponseDto.cs`
  - `Interfaces/`
    - `IUnitOfWork.cs`
    - `IGenericRepository.cs`
    - `IEmpService.cs`
  - `Mapping/`
    - `MapProfile.cs`
  - `Validator/`
    - `CreateValidator.cs`
    - `UpdateValidator.cs`

- `EmployeeManagementSystem.Domain`
  - `Entities/`
    - `Employee.cs`
    - `BaseEntity.cs`
  - `Enums/`
    - `Deparment.cs`

- `EmployeeManagementSystem.Infrastructure`
  - `Data/`
    - `AppDbContext.cs`
  - `Repository/`
    - `UnitOfWork.cs`
    - `GenericRepository.cs`
  - `Migrations/`
    - `20260601154019_InitialCreate.cs`

- `EmployeeManagementSystem.Tests`
  - `Services/`
    - `EmployeeServiceTests.cs`
  - `Controllers/`
    - `EmployeeControllerTests.cs`

- `EmployeeManagementSystem.Tests.NUnit`
  - `GlobalUsings.cs`
  - `Services/`
    - `EmployeeServiceTests.cs`
  - `Controllers/`
    - `EmployeeControllerTests.cs`

## Solution files

- Solution root contains the project/solution files and this README.

