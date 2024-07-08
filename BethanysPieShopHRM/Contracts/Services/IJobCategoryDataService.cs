using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Services;

public interface IJobCategoryDataService
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}