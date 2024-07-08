using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public class JobCategoryDataService(IJobCategoryRepository jobCategoryRepository) : IJobCategoryDataService
{
    public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
    {
        return await jobCategoryRepository.GetAllJobCategories();
    }

    public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
    {
        return await jobCategoryRepository.GetJobCategoryById(jobCategoryId);
    }
}