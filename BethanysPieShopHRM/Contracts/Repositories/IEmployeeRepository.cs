using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int employeeId);
}