using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Windows;
using WpfIocDemo.Services;

namespace WpfIocDemo;

public partial class App : Application
{
    public App()
    {
        Services = ConfigureServices();
    }

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ILogger>(_ =>
        {
            return new LoggerConfiguration().MinimumLevel
                .Debug()
                .WriteTo.File("log.txt")
                .CreateLogger();
        });
        services.AddSingleton<IWebClient, WebClient>();
        services.AddSingleton<ICatFactsService, CatFactsService>();
        services.AddSingleton<IMessageBoxService, MessageBoxService>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MainWindow>(sp => new MainWindow { DataContext = sp.GetService<MainWindowViewModel>() });

        return services.BuildServiceProvider();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = Services.GetService<MainWindow>();
        mainWindow!.Show();
    }
}
