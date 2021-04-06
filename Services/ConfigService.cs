using System.IO;
using Newtonsoft.Json;
using LoggerAsync.Configs;
using LoggerAsync.Configs.Abstractions;

namespace LoggerAsync.Services
{
    public class ConfigService : IConfigService
    {
        public LoggerConfig GetConfiguration()
        {
            var configFrom = File.ReadAllText(LoggerConfiguration.ConfigSource);
            var configuration = JsonConvert.DeserializeObject<LoggerConfig>(configFrom);
            return configuration;
        }
    }
}
