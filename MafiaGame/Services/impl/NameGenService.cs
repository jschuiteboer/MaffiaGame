using System;

namespace MafiaGame.Services.impl
{
    public class NameGenService : INameGenService
    {
        private static readonly string[] BANK_NAMES = new string[] {
            "Nation Financial Holdings",
            "Green Market Bank Corp.",
            "Midland Holdings Inc.",
            "Aspire Financial Corp.",
            "Origin Banks Inc.",
            "Groundwork Bank Group",
            "Associated Trust Corp.",
            "Cognate Bank Inc.",
            "Padlock Financial Corp.",
            "General Trust Corp.",
            "Oculus Financial Services",
            "Faith Corporation",
            "Provenance Holdings",
            "Jones Banks",
            "Commonwealth Bank Group",
            "Summit Financial",
            "Bright Horizon Holding Company",
            "Apex Bank System",
            "Goldguard Banks Inc.",
            "Zion Bank System",
        };

        private static readonly string[] STORE_NAMES = new string[] {
            "Moonlit Acoustics",
            "Spirit Networks",
            "Cliffoods",
            "Spectertainment",
            "Junglectics",
            "Lagoonshack",
            "Mermaidtube",
            "Honeyphone",
            "Purple Solutions",
            "Buck Motors",
            "Starecords",
            "Ecliprises",
            "Leopardworks",
            "Riddleforce",
            "Happyfruit",
            "Beedle Arts",
            "Sun Navigations",
            "Neroductions",
            "Riddleshow",
            "The Spirit",
            "That's Amore Pizzeria",
            "Dough Oh Pizzeria",
            "Cheesus Crust Pizzeria",
            "Pretty Paws",
            "Shear Critters",
            "Fur Styling",
            "Comb and Collar",
            "Hairballs",
            "Grand Plaza",
            "Supremacy Square",
            "The Malt Bite",
            "The Beach Peasant",
            "The Bengal Blanket",
            "The Caviar Tower",
            "The Central Barbecue",
            "Embers",
            "The Lighthouse",
            "Roots",
            "Mumbles",
            "The Empress",
            "The Ruby Blossom",
            "The Mushy Clam",
            "The Savory Fiddler",
            "The Mad Devil",
            "The Island Hog",
            "Elements",
            "Bones",
            "Elements",
            "Lemon Grass",
            "Trinity",
            "la Fenêtre de Poivre",
            "le Jardin Acide",
            "le Chevalier des Caraïbes",
            "la Liaison de la Flamme",
            "The Bouncy Carpet",
            "The Golden River",
            "The Steel Pen",
            "The Lazy Peach",
            "What Ales You",
            "Aristo-Cut",
            "The Plain Berry",
            "The Wrestling Pagoda",
            "The Angry Bee Drugstore",
            "The Glowing Wall Toy Store",
            "Wok This Way",
            "Sofa So Good",
            "Hair Force One",
            "Bar Humbug",
            "The Fair Carpet",
            "Pizza My Heart",
            "Thai Ping",
            "Hairs Johnny",
            "The Famous Walnut",
            "The Last Joker Antique Store",
            "Buy the Way",
        };

        private static readonly string[] AIRPORT_NAMES = new string[] {
            "Hominy Flightpark",
            "Rend Lake Conservancy Helicopters",
            "Hubler International Airport",
            "Somerset Airport",
            "Spatchust District Airport",
            "Flechroungs International Airport",
            "Hanks Hangar Airstrip",
            "H. Reder International Airport",
            "Clinton District Airport",
            "Eaddercherry Strip",
            "Will Landing",
            "Air Logistics Service",
        };

        private static readonly string[] POLICE_STATION_NAMES = new string[] {
            "Federal Agency of Secret Misconduct",
            "Federal Agency of Civil Crime",
            "Federal Department of Civil Criminal Intelligence",
            "Ballistic Enforcement Bureau",
            "Terrorism Department",
            "Corruption Division",
            "Royal Bureau of Civil Corruption Control",
            "Federal Agency of Probation Violation",
            "Protection Intelligence Unit",
            "Terror Intelligence Division",
            "Unit of Federal Crime Scene Investigation",
            "National Customs and Border Enforcement Unit",
        };

        private readonly Random _rand = new Random(0);

        public string GetNextNameForABank()
        {
            return this.GetNextNameFrom(BANK_NAMES);
        }

        public string GetNextNameForAnAirport()
        {
            return this.GetNextNameFrom(AIRPORT_NAMES);
        }

        public string GetNextNameForAPoliceStation()
        {
            return this.GetNextNameFrom(POLICE_STATION_NAMES);
        }

        public string GetNextNameForAStore()
        {
            return this.GetNextNameFrom(STORE_NAMES);
        }

        //TODO: don't repeat names? / namespace names?
        private string GetNextNameFrom(string[] nameArray)
        {
            return nameArray[_rand.Next(0, nameArray.Length)];
        }
    }
}