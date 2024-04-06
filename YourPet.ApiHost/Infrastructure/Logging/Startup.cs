using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace YourPet.ApiHost.Infrastructure.Logging
{
	public static class StartupEx
    {
        public static ILogger CreateStartupLogger(this IConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration();
            var serilogOptions = configuration.GetOptions<SerilogOptions>("Serilog");

            if (!Enum.TryParse<LogEventLevel>(serilogOptions.Level, true, out var level))
            {
                level = LogEventLevel.Information;
            }

            if (serilogOptions.SelfLogEnabled)
            {
                Serilog.Debugging.SelfLog.Enable(m => Console.WriteLine(m));
            }

            loggerConfiguration
                .MinimumLevel.Is(level)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext();

            if (serilogOptions.ConsoleEnabled)
            {
                loggerConfiguration.WriteTo.Console();
            }

            var fileLogOptions = serilogOptions.FileLog;
            if (fileLogOptions != null && fileLogOptions.Enabled)
            {
                if (!Enum.TryParse<RollingInterval>(serilogOptions.FileLog.RollingInterval, true, out var rollingInterval))
                    rollingInterval = RollingInterval.Day;

                loggerConfiguration.WriteTo.File(fileLogOptions.Path,
                    level,
                    fileLogOptions.OutputTemplate,
                    rollingInterval: rollingInterval);
            }

            return loggerConfiguration.CreateLogger();
        }

        public static IHostBuilder UseSerilogLogging(this IHostBuilder builder)
        {
            return builder.UseSerilog((ctx, configuration) =>
            {
                var serilogOptions = ctx.Configuration.GetOptions<SerilogOptions>("Serilog");

                if (!Enum.TryParse<LogEventLevel>(serilogOptions.Level, true, out var level))
                {
                    level = LogEventLevel.Information;
                }

                if (serilogOptions.SelfLogEnabled)
                {
                    Serilog.Debugging.SelfLog.Enable(m => Console.WriteLine(m));
                }

                var efLogLevel = ctx.HostingEnvironment.IsDevelopment() ? LogEventLevel.Information : LogEventLevel.Warning;

                configuration
                    .MinimumLevel.ControlledBy(new DynamicLogLevelSwitch(ctx.Configuration, "Serilog:Level"))
                    .MinimumLevel.Override("Microsoft", new DynamicLogLevelSwitch(ctx.Configuration, "Serilog:MicrosoftLevel"))
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", efLogLevel)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", ctx.HostingEnvironment.EnvironmentName);

                var fileLogOptions = serilogOptions.FileLog;
                if (fileLogOptions != null && fileLogOptions.Enabled)
                {
                    if (!Enum.TryParse<RollingInterval>(serilogOptions.FileLog.RollingInterval, true, out var rollingInterval))
                        rollingInterval = RollingInterval.Day;

                    configuration.WriteTo.File(fileLogOptions.Path,
                        level,
                        fileLogOptions.OutputTemplate,
                        rollingInterval: rollingInterval);
                }

                if (serilogOptions.ConsoleEnabled)
                {
                    configuration.WriteTo.Console();
                }
            });
        }
    }
}
