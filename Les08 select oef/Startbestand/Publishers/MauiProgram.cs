using Microsoft.Extensions.Logging;
using Publishers.Data.Interfaces;
using Publishers.Data.Repositories;

namespace Publishers
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<StoresPage>();
            builder.Services.AddSingleton<EmployeesPage>();

            builder.Services.AddSingleton<StoresViewModel>();
            builder.Services.AddSingleton<EmployeesViewModel>();

            builder.Services.AddSingleton< IStoreRepository,StoreRepository>();

            return builder.Build();
        }
    }
}
