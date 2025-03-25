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

            builder.Services.AddSingleton<StoresViewModel>();
            builder.Services.AddSingleton<EmployeesViewModel>();
            builder.Services.AddSingleton<NavigationPropertiesViewModel>();

            builder.Services.AddSingleton <IEmployeesRepository, EmployeesRepository>();
            builder.Services.AddSingleton<IStoresRepository, StoresRepository>();
            builder.Services.AddSingleton<IPublishersRepository , PublishersRepository>();
            builder.Services.AddSingleton<IJobsRepository, JobsRepository>();
            builder.Services.AddSingleton<IBookRepository, BookRepository>();
            builder.Services.AddSingleton<ISalesRepository, SalesRepository>();

            return builder.Build();
        }
    }
}