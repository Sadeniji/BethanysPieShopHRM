using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public class TimeRegistrationDataService(ITimeRegistrationRepository timeRegistrationRepository) : ITimeRegistrationDataService
{
    public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
    {
        return await timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);
    }

    public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
    {
        return await timeRegistrationRepository.GetPagedTimeRegistrationsForEmployee(employeeId, pageSize, start);
    }

    public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
    {
        return await timeRegistrationRepository.GetTimeRegistrationCountForEmployeeId(employeeId);
    }
}