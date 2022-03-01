using NLog;
using NLog.Web;
using WebApi;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

var config = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").Build();

try
{
    logger.Debug("init main");
    CreateHostBuilder(args).Build().Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.UseConfiguration(config);
        webBuilder.UseKestrel();
    }).ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    })
      .UseNLog();