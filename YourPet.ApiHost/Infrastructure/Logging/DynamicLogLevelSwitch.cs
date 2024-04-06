using Microsoft.Extensions.Primitives;
using Serilog.Core;
using Serilog.Events;

namespace YourPet.ApiHost.Infrastructure.Logging
{
    public class DynamicLogLevelSwitch : LoggingLevelSwitch
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;
        private IChangeToken _token;

        public DynamicLogLevelSwitch(IConfiguration configuration, string key)
        {
            _configuration = configuration;
            _key = key;

            TrySetMinimumLevel();

            _token = configuration.GetSection("Serilog").GetReloadToken();
            _token.RegisterChangeCallback(OnLoggingReload, null);
        }

        private void OnLoggingReload(object _)
        {
            TrySetMinimumLevel();
            _token = _configuration.GetSection("Serilog").GetReloadToken();
            _token.RegisterChangeCallback(OnLoggingReload, null);
        }

        private void TrySetMinimumLevel()
        {
            if (Enum.TryParse(_configuration[_key], out LogEventLevel level))
            {
                MinimumLevel = level;
            }
        }
    }
}
