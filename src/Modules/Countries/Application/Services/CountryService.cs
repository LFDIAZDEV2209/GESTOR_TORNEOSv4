using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        try
        {
            var countries = await _countryRepository.GetAllAsync();

            if (countries == null)
            {
                Console.WriteLine("No countries found");
                return Enumerable.Empty<Country>();
            }

            return countries;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting all countries: {ex.Message}");
            return Enumerable.Empty<Country>();
        }
    }

    public async Task<Country?> GetByIdAsync(int id)
    {
        try
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                Console.WriteLine("No country found");
                return null;
            }

            return country;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting country by id: {ex.Message}");
            return null;
        }
    }
}