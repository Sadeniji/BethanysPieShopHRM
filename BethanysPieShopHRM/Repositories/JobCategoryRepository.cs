using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class JobCategoryRepository(IDbContextFactory<AppDbContext> dbContextFactory): IJobCategoryRepository, IDisposable
{
    private readonly AppDbContext _appDbContext = dbContextFactory.CreateDbContext();
    
    public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
    {
        return await Task.FromResult(_appDbContext.JobCategories);
    }

    public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
    {
        return await _appDbContext.JobCategories.FirstOrDefaultAsync(j => j.JobCategoryId == jobCategoryId);
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}