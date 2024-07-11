using System.Text.Json;
using BethanysPieShopHRM.Shared;
using Blazored.LocalStorage;
using BethanysPieShopHRM.Client.Helper;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Client.Services;

public class ClientEmployeeDataService(HttpClient httpClient, ILocalStorageService localStorageService) : IEmployeeDataService
{
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        bool employeeEmployeeExpirationExist = await localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListExpirationKey);

        if (employeeEmployeeExpirationExist)
        {
            DateTime employeeListExpiration = await localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.EmployeesListExpirationKey);

            if (employeeListExpiration > DateTime.Now)  // get from local storage
            {
                if (await localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListKey))
                {
                    return await localStorageService.GetItemAsync<List<Employee>>(
                        LocalStorageConstants.EmployeesListKey);
                }   
            }
        }
        var employees = await JsonSerializer
            .DeserializeAsync<IEnumerable<Employee>>(
                await httpClient.GetStreamAsync("api/employee"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        await localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListKey, employees);
        await localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey,
            DateTime.Now.AddMinutes(1));
        
        return employees;
    }

    public Task<Employee> GetEmployeeDetails(int employeeId)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }
}