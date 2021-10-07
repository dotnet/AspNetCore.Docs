using Microsoft.EntityFrameworkCore;

namespace EFConfigSample;
#region snippet1
public class EFConfigurationSource : IConfigurationSource
{
    private readonly Action<DbContextOptionsBuilder> _optionsAction;

    public EFConfigurationSource(Action<DbContextOptionsBuilder> optionsAction) => _optionsAction = optionsAction;

    public IConfigurationProvider Build(IConfigurationBuilder builder) => new EFConfigurationProvider(_optionsAction);
}
#endregion
