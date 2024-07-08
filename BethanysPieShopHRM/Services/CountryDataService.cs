using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.Services;

public class CountryDataService(ICountryRepository countryRepository) : ICountryDataService
{
    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        return await countryRepository.GetAllCountries();
    }

    public async Task<Country> GetCountryById(int countryId)
    {
        return await countryRepository.GetCountryById(countryId);
    }
}