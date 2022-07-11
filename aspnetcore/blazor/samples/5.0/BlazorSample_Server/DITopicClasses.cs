public class Setting
{
    public string SettingName { get; set; }
    public string SettingValue { get; set; }
}

public interface IUserService
{
    public string Name { get; set; }
}

public interface ISettingService
{
    public IList<Setting> GetSettings();
}
