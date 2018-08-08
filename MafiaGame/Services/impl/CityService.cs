using MafiaGame.Models;
using System;
using System.Collections.Generic;

namespace MafiaGame.Services.impl
{
    public class CityService : ICityService
    {
        private List<City> _cities;

        private List<string> _cityNames;

        public CityService(IMapService mapService)
        {
            this._cities = new List<City> {
                new City("Colcord", mapService.CreateMapFromSeed(234347)),
                new City("Windstead", mapService.CreateMapFromSeed(2346234)),
                new City("Esbridge", mapService.CreateMapFromSeed(232346)),
                new City("New Bigham", mapService.CreateMapFromSeed(843455)),
                new City("Repenburg", mapService.CreateMapFromSeed(247)),
                new City("Richminster", mapService.CreateMapFromSeed(3457)),
            };
        }

        public IList<string> GetCityNames()
        {
            if(_cityNames == null)
            {
                _cityNames = new List<string>();
                foreach (City city in this._cities)
                {
                    this._cityNames.Add(city.Name);
                }
            }

            return _cityNames;
        }
        
        public IReadOnlyCollection<City> GetCities()
        {
            return this._cities.AsReadOnly();
        }

        public City GetCityFromName(string name)
        {
            foreach (City city in this._cities)
            {
                if(city.Name == name)
                {
                    return city;
                }
            }

            throw new ArgumentException("not a valid city: " + name);
        }

        public IList<City> GetConnectedCities(City city)
        {
            Validation.RequireNonNull(city, "city");

            List<City> connectedCities = new List<City>(this.GetCities());
            
            // TODO: make city comparable
            connectedCities.Remove(city);

            return connectedCities;
        }
    }
}