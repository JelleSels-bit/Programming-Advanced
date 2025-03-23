using Orders.ViewModels;
using Orders.Views;

namespace Orders;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<OrderRepository>();
        builder.Services.AddSingleton<KlantRepository>();
        builder.Services.AddSingleton<WerknemerRepository>();

        builder.Services.AddSingleton<WerknemersPage>();
        builder.Services.AddSingleton<WerknemersViewModel>();

        builder.Services.AddSingleton<OrdersPage>();
        builder.Services.AddSingleton<OrdersViewModel>();

        builder.Services.AddSingleton<OrdersExtendedPage>();
        builder.Services.AddSingleton<OrdersExtendedViewModel>();


        builder.Services.AddSingleton<OrdersCrudPage>();
        builder.Services.AddSingleton<OrdersCrudViewModel>();
        return builder.Build();
    }
}