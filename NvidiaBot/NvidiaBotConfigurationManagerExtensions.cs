using Microsoft.Extensions.Configuration;

namespace NvidiaBot;

public static class NvidiaBotConfigurationManagerExtensions
{
    public static ConfigurationManager AddNvidiaBotConfiguration<T>(this ConfigurationManager configuration) where T : class
    {
        configuration.AddUserSecrets<T>(optional: false);
        return configuration;
    }
}
