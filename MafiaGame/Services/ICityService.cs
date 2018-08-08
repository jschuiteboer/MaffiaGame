using MafiaGame.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MafiaGame.Services
{
    public interface ICityService
    {
        IList<string> GetCityNames();

        IReadOnlyCollection<City> GetCities();

        City GetCityFromName(string name);

        IList<City> GetConnectedCities(City city);
    }
}