using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Interfaces;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class PlanetService : IPlanetService
    {
        // Planet names are ©1974-1981 BBC.
        //     https://www.bbc.co.uk/programmes/b006q2x0
        // Planet images are courtesy of the National Aeronautics and 
        //     Space Administration (NASA). https://www.nasa.gov/
        private IList<Planet> _planets = new List<Planet>
        {
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001417/GSFC_20171208_Archive_e001417~orig.jpg", Name = "Skaro" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22069/PIA22069~orig.jpg", Name = "Skonnos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA19344/PIA19344~orig.jpg", Name = "Argolis" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA13994/PIA13994~orig.jpg", Name = "Castrovalva" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e000019/GSFC_20171208_Archive_e000019~orig.png", Name = "Diplos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22084/PIA22084~orig.jpg", Name = "Karn" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22087/PIA22087~orig.jpg", Name = "Logopolis" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22098/PIA22098~orig.jpg", Name = "Minyos II" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA18018/PIA18018~orig.jpg", Name = "Ribos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA14888/PIA14888~orig.jpg", Name = "Skaar" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001427/GSFC_20171208_Archive_e001427~orig.jpg", Name = "Tara" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e000132/GSFC_20171208_Archive_e000132~orig.jpg", Name = "Traken" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA01253/PIA01253~orig.jpg", Name = "Usurius" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA05988/PIA05988~orig.jpg", Name = "Vampire Planet" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001545/GSFC_20171208_Archive_e001545~orig.png", Name = "Zanak" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA19833/PIA19833~orig.jpg", Name = "Zeos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e002172/GSFC_20171208_Archive_e002172~orig.jpg", Name = "Zeta Minor" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA20068/PIA20068~orig.jpg", Name = "Voga" },
        };

        public IEnumerable<Planet> GetPlanets(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return _planets;
            }
            else
            {
                return _planets.Where(f => 
                    f.Name.StartsWith(filter, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void AddPlanet(Planet Planet)
        {
            _planets.Add(Planet);
        }
    }
}
