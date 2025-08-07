# Employee Management System - MVC Project

## Overview
This project is an MVC-based Employee Management System that provides CRUD operations for employee data with department associations. It follows a layered architecture with separation of concerns between data access, business logic, and presentation layers.

## Project Structure

### Layers
1. **Data Access Layer**
   - Entity models (Employee, Department)
   - Repositories (EmployeeRepository, DepartmentRepository)
   - Unit of Work pattern implementation

2. **Business Logic Layer**
   - Services (EmployeeServices, DepartmentServices)
   - DTOs (Data Transfer Objects)
   - AutoMapper for object-object mapping

3. **Presentation Layer**
   - MVC controllers
   - Views for user interaction

## Key Features

### Employee Management
- ✅ Get all employees (with search functionality)
- ✅ Get employee details by ID
- ✅ Create new employees (with image upload)
- ✅ Update existing employees
- ✅ Soft delete employees (mark as deleted)

### Department Management
- ✅ Get all departments
- ✅ Get department details by ID
- ✅ Add new departments
- ✅ Update existing departments
- ✅ Delete departments

## Technical Details

### Dependencies
- **AutoMapper** - For object-object mapping
- **Entity Framework Core** - For data access (implied by repository pattern)
- **Dependency Injection** - For service registration

### Architecture Patterns
- **MVC** (Model-View-Controller)
- **Repository Pattern** - For data access abstraction
- **Unit of Work** - For transaction management
- **DTO Pattern** - For data transfer between layers

## Getting Started

### Prerequisites
- .NET 6+ SDK
- SQL Server (or compatible database)
- IDE (Visual Studio, VS Code, etc.)

### Installation
1. Clone the repository
2. Configure database connection in appsettings.json
3. Run database migrations (if using EF Core migrations)
4. Build and run the application

## API Endpoints (Sample)

### Employee Endpoints
```
GET /api/employees - Get all employees
GET /api/employees/{id} - Get employee by ID
POST /api/employees - Create new employee
PUT /api/employees/{id} - Update employee
DELETE /api/employees/{id} - Delete employee
```

### Department Endpoints
```
GET /api/departments - Get all departments
GET /api/departments/{id} - Get department by ID
POST /api/departments - Create new department
PUT /api/departments/{id} - Update department
DELETE /api/departments/{id} - Delete department
```

## Code Examples

### Employee Service
```csharp
// Get all employees with optional search
public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withtracking = false)
{
    IEnumerable<Employee> employees;
    if(string.IsNullOrWhiteSpace(EmployeeSearchName))
        employees = _unitOfWork._employeerepository.GetAll(withtracking);
    else
        employees = _unitOfWork._employeerepository.GetAll(
            E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
    
    return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
}

// Create new employee with image upload
public int CreateEmployee(CreateEmployeeDto employeedto)
{
    var employee = _mapper.Map<Employee>(employeedto);
    if(employeedto.Image is not null)
    {
        employee.ImageName = _attachmentService.UploadFile(employeedto.Image, "Images");
    }
    return _unitOfWork._employeerepository.Insert(employee);
}
```

