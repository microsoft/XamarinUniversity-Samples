using System.Collections.Generic;

namespace Planets
{
    public static class PlanetDataRepository
    {
        public static IList<Planet> Planets { get; private set; }

        static PlanetDataRepository()
        {
            Planets = new List<Planet>()
            {
                new Planet() {Name = "Mercury", Id = 0, Image = "mercury.png"},
                new Planet() {Name = "Venus", Id = 1, Image = "venus.png"},
                new Planet() {Name = "Earth", Id = 2, Image = "earth.png"},
                new Planet() {Name = "Mars", Id = 3, Image = "mars.png"},
                new Planet() {Name = "Jupiter", Id = 4, Image = "jupiter.png"},
                new Planet() {Name = "Saturn", Id = 5, Image = "saturn.png"},
                new Planet() {Name = "Uranus", Id = 6, Image = "uranus.png"},
                new Planet() {Name = "Neptune", Id = 7, Image = "neptune.png"},
            };
        }

        public static Planet GetPlanetFromId (int id)
        {
            return Planets[id];
        }
    }
}