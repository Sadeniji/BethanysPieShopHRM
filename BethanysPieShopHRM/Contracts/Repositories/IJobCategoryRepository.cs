using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Contracts.Repositories;

public interface IJobCategoryRepository
{
    Task<IEnumerable<JobCategory>> GetAllJobCategories();
    Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}