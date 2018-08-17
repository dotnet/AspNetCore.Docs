using System.Collections.Generic;
using ConfigurationSample.Models;

namespace ConfigurationSample.ViewModels
{
    public class Config
    {
        public IEnumerable<KeyValuePair<string, string>> FilteredConfiguration { get; set; }
        public Starship Starship { get; set; }
        public TvShow TvShow { get; set; }
        public ArrayExample ArrayExample { get; set; }
        public JsonArrayExample JsonArrayExample { get; set; }
    }
}
