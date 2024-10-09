using Application;
using Infrastructure;
using Inventory;

var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();

var host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "InventoryService";
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(builder.Configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
