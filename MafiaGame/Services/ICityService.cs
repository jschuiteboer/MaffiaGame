using MafiaGame.Models;
using System.Collections.Generic;

namespace MafiaGame.Services
{
    public interface ICityService
    {
        List<string> GetCityNames();

        List<City> GetCities();

        City GetCityFromName(string name);
    }
}