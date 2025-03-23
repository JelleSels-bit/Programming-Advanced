using Microsoft.Extensions.Logging;

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
            builder.Services.AddSingleton<NavigationPropertiesPage>();
            builder.Services.AddSingleton<CrudPage>();

            builder.Services.AddSingleton<StoresViewModel>();
            builder.Services.AddSingleton<EmployeesViewModel>();
            builder.Services.AddSingleton<NavigationPropertiesViewModel>();
            builder.Services.AddSingleton<CrudViewModel>();

            builder.Services.AddSingleton<IEmployeesRepository,EmployeesRepository>();
            builder.Services.AddSingleton<StoresRepository>();
            builder.Services.AddSingleton<PublishersRepository>();
            builder.Services.AddSingleton<JobsRepository>();
            builder.Services.AddSingleton<BooksRepository>();
            builder.Services.AddSingleton<SalesRepository>();

            return builder.Build();
        }
    }
}