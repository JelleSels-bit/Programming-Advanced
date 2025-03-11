using Microsoft.Extensions.Logging;

namespace Orders
{
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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<WerknemersPage>();
            builder.Services.AddSingleton<OrdersPage>();

            builder.Services.AddSingleton<WerknemersViewModel>();
            builder.Services.AddSingleton<OrdersViewModel>();

            builder.Services.AddSingleton<WerknemerRepository>();
            builder.Services.AddSingleton<OrderRepository>();

            return builder.Build();
        }
    }
}