using Application;
using Azure.Identity;
using Infrastructure;
using Infrastructure.KeyVault;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((host, builder) =>
    {
        builder.AddEnvironmentVariables();
        var configuration = builder.Build();
        builder.AddAzureKeyVault(new Uri(configuration["KeyVaultUrl"]), new DefaultAzureCredential());
    })
    .ConfigureServices((builder, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.Configure<KeyVaultSecret>(builder.Configuration);

        services.RegisterApplication();
        services.RegisterInfrastructure(builder.Configuration);
    })
    .Build();

host.Run();
