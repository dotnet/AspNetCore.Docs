
using Microsoft.EntityFrameworkCore;

namespace EFConfigSample;
#region snippet1
public static class EntityFrameworkExtensions
{
    public static IConfigurationBuilder AddEFConfiguration(
               this IConfigurationBuilder builder,
               Action<DbContextOptionsBuilder> optionsAction)
    {
        return builder.Add(new EFConfigurationSource(optionsAction));
    }
}
#endregion
