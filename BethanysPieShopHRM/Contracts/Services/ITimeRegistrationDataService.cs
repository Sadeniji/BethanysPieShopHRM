using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.Contracts.Services;

public interface ITimeRegistrationDataService
{
    Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
    Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
    Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId);
}