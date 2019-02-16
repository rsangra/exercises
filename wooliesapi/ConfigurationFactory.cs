using Microsoft.Extensions.Configuration;

namespace WooliesX.Exercises
{
    public class ConfigurationFactory
    {
        public IConfiguration Create(string configDirectory)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(configDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
            return config;
        }    
    }
}