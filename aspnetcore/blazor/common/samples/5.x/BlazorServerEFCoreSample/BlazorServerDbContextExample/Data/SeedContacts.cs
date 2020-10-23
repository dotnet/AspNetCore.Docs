using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerDbContextExample.Data
{
    /// <summary>
    /// Generates desired number of random contacts.
    /// </summary>
    public class SeedContacts
    {
        /// <summary>
        /// Use these to make names.
        /// </summary>
        private readonly string[] _gems = new[] {
            "Diamond",
        "Crystal",
        "Morion",
        "Azore",
        "Sapphire",
        "Cobalt",
        "Aquamarine",
        "Montana",
        "Turquoise",
        "Lime",
        "Erinite",
        "Emerald",
        "Turmaline",
        "Jonquil",
        "Olivine",
        "Topaz",
        "Citrine",
        "Sun",
        "Quartz",
        "Opal",
        "Alabaster",
        "Rose",
        "Burgundy",
        "Siam",
        "Ruby",
        "Amethyst",
        "Violet",
        "Lilac"};

        /// <summary>
        /// Combined with things for last names.
        /// </summary>
        private readonly string[] _colors = new[]
        {
            "Blue",
            "Aqua",
            "Red",
            "Green",
            "Orange",
            "Yellow",
            "Black",
            "Violet",
            "Brown",
            "Crimson",
            "Gray",
            "Cyan",
            "Magenta",
            "White",
            "Gold",
            "Pink",
            "Lavender"
        };

        /// <summary>
        /// Also helpful for names.
        /// </summary>
        private readonly string[] _things = new[]
        {
            "beard",
            "finger",
            "hand",
            "toe",
            "stalk",
            "hair",
            "vine",
            "street",
            "son",
            "brook",
            "river",
            "lake",
            "stone",
            "ship"
        };

        /// <summary>
        /// Street names.
        /// </summary>
        private readonly string[] _streets = new[]
        {
            "Broad",
            "Wide",
            "Main",
            "Pine",
            "Ash",
            "Poplar",
            "First",
            "Third",
        };

        /// <summary>
        /// Types of streets.
        /// </summary>
        private readonly string[] _streetTypes = new[]
        {
            "Street",
            "Lane",
            "Place",
            "Terrace",
            "Drive",
            "Way"
        };

        /// <summary>
        /// More uniqueness.
        /// </summary>
        private readonly string[] _directions = new[]
        {
            "N",
            "NE",
            "E",
            "SE",
            "S",
            "SW",
            "W",
            "NW"
        };

        /// <summary>
        /// A sampling of cities.
        /// </summary>
        private readonly string[] _cities = new[]
        {
            "Austin",
            "Denver",
            "Fayetteville",
            "Des Moines",
            "San Francisco",
            "Portland",
            "Monroe",
            "Redmond",
            "Bothel",
            "Woodinville",
            "Kent",
            "Kennesaw",
            "Marietta",
            "Atlanta",
            "Lead",
            "Spokane",
            "Bellevue",
            "Seattle"
        };

        /// <summary>
        /// State list.
        /// </summary>
        private readonly string[] _states = new[]
        {
            "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL",
            "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA",
            "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE",
            "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
            "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT",
            "VA", "WA", "WV", "WI", "WY"
        };

        /// <summary>
        /// Get some randominzation in play.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Picks a random item from a list.
        /// </summary>
        /// <param name="list">A list of <c>string</c> to parse.</param>
        /// <returns>A single item from the list.</returns>
        private string RandomOne(string[] list)
        {
            var idx = _random.Next(list.Length - 1);
            return list[idx];
        }

        /// <summary>
        /// Make a new contact.
        /// </summary>
        /// <returns>A random <see cref="Contact"/> instance.</returns>
        private Contact MakeContact()
        {
            var contact = new Contact
            {
                FirstName = RandomOne(_gems),
                LastName = $"{RandomOne(_colors)}{RandomOne(_things)}",
                Phone = $"({_random.Next(100, 999)})-555-{_random.Next(1000, 9999)}",
                Street = $"{_random.Next(1, 99999)} {_random.Next(1, 999)}" +
                $" {RandomOne(_streets)} {RandomOne(_streetTypes)} {RandomOne(_directions)}",
                City = RandomOne(_cities),
                State = RandomOne(_states),
                ZipCode = $"{ _random.Next(10000, 99999)}"
            };
            return contact;
        }

        public async Task SeedDatabaseWithContactCountOfAsync(ContactContext context, int totalCount)
        {
            var count = 0;
            var currentCycle = 0;
            while (count < totalCount)
            {
                var list = new List<Contact>();
                while (currentCycle++ < 100 && count++ < totalCount)
                {
                    list.Add(MakeContact());
                }
                if (list.Count > 0)
                {
                    context.Contacts.AddRange(list);
                    await context.SaveChangesAsync();
                }
                currentCycle = 0;
            }
        }
    }
}
