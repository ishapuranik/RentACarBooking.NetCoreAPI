using Microsoft.Extensions.Configuration;

namespace Bookings.Shared.Config
{
    public class ConfigWrapper : IConfigWrapper
    {
        private readonly IConfiguration _config;
        public ConfigWrapper(IConfiguration config)
        {
            _config = config;
        }
        public string Get(string key)
        {
            return _config[key];
        }
        public IEnumerable<string> GetSection(string key)
        {
            return _config.GetSection(key)?.Get<string[]>();
        }
    }
}
