using MafiaGame.Models;
using System.Collections.Generic;

namespace MafiaGame.Services.impl
{
    public class CityService : ICityService
    {
        private List<City> cities = new List<City>
        {
            new City()
            {
                Name = "Colcord",
            },
            new City()
            {
                Name = "Windstead",
            },
            new City()
            {
                Name = "Esbridge",
            },
            new City()
            {
                Name = "New Bigham",
            },
            new City()
            {
                Name = "Repenburg",
            },
            new City()
            {
                Name = "Richminster",
            },
        };

        public List<string> CityNames { get; private set; }

        public CityService()
        {
            this.CityNames = new List<string>();

            foreach(City city in this.cities) {
                this.CityNames.Add(city.Name);
            }
        }

        public List<string> GetCityNames()
        {
            return this.CityNames;
        }
    }
}