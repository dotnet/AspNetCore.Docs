using System;

namespace ConfigurationSample.Models
{
    #region snippet1
    public class TvShow
    {
        public Metadata? Metadata { get; set; }
        public Actors? Actors { get; set; }
        public string? Legal { get; set; }
    }

    public class Metadata
    {
        public string? Series { get; set; }
        public string? Title { get; set; }
        public DateTime AirDate { get; set; }
        public int Episodes { get; set; }
    }

    public class Actors
    {
        public string? Names { get; set; }
    }
    #endregion
}
