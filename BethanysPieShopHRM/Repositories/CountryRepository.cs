using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Repositories;

public class CountryRepository(IDbContextFactory<AppDbContext> dbContextFactory) : ICountryRepository, IDisposable
{
    private readonly AppDbContext _appDbContext = dbContextFactory.CreateDbContext();

    public void Dispose()
    {
        _appDbContext.Dispose();
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await Task.FromResult(_appDbContext.Countries);
    }

    public async Task<Country> GetCountryById(int countryId)
    {
        return await _appDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId);
    }
}