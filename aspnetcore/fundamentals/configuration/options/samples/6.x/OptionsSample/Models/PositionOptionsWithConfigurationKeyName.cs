namespace SampleApp.Models
{
    #region snippet
    public class PositionOptionsWithConfigurationKeyName
    {
        public const string Position = "Position";

        [ConfigurationKeyName("position-title")]
        public string Title { get; set; } = String.Empty;

        [ConfigurationKeyName("position-name")]
        public string Name { get; set; } = String.Empty;
    }
    #endregion
}
