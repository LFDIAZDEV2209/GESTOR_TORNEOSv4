using GESTOR_TORNEOSv4.src.Modules.Application.Interfaces;
using GESTOR_TORNEOSv4.src.Modules.Domain.Entities;

namespace GESTOR_TORNEOSv4.src.Modules.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City?> GetCityByIdAsync(int id)
    {
        try
        {
            var city = await _cityRepository.GetByIdAsync(id);

            if (city == null)
            {
                Console.WriteLine($"City with ID {id} not found.");
                return null;
            }

            return city;
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error retrieving city with ID {id}: {ex.Message}", ex);
            return null;
        }
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        try
        {
            var cities = await _cityRepository.GetAllAsync();

            if (cities == null || !cities.Any())
            {
                Console.WriteLine("No cities found.");
                return Enumerable.Empty<City>();
            }

            return cities;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving all cities: {ex.Message}", ex);
            return Enumerable.Empty<City>();
        }
    }
}
