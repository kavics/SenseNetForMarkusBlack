using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
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
            })
            .ConfigureServices((context, services) => {
                services.AddSenseNetClient()
                    .ConfigureSenseNetRepository(repositoryOptions =>
                    {
                        context.Configuration.GetSection("sensenet:repository").Bind(repositoryOptions);
                    });

                services.AddTransient<Form1>();
            });
    }
}