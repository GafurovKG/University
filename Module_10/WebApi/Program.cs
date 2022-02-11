using WebApi;

var config = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").Build();

var builder = Host.CreateDefaultBuilder(args)
    //.ConfigureAppConfiguration(builder =>
    //{
    //    builder.AddUserSecrets<Program>();
    //})
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
        webBuilder.UseConfiguration(config);
        webBuilder.UseKestrel();
    })
    .Build();

builder.Run();