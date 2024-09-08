using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SenseNet.Client;
using SenseNet.Extensions.DependencyInjection;

namespace SenseNetForMarkusBlack;

internal class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
        Application.Run(ServiceProvider.GetRequiredService<Form1>());
    }

    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(configBuilder =>
            {
                configBuilder.AddUserSecrets<Program>();
//configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) => {
                services.AddOptions();
                services.Configure<RepositoryOptions>(context.Configuration.GetSection("sensenet:repository"));
                services.AddSenseNetClient()
                    .ConfigureSenseNetRepository(repositoryOptions =>
                    {
                        context.Configuration.GetSection("sensenet:repository").Bind(repositoryOptions);
                    });

                services.AddTransient<Form1>();
                services.AddSingleton<IDataHandler, RepositoryDataHandler>();
            });
    }
}