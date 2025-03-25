using Microsoft.Extensions.Logging;
using Publishers.Data.Interface;
using Publishers.Data.Repository;

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

            builder.Services.AddSingleton<IStoresRepository, StoresRepository>();
            builder.Services.AddSingleton<IEmployeeInterface,EmployeeRepository>();
            builder.Services.AddSingleton<IJobRepository,JobRepository>();
            builder.Services.AddSingleton<IPublishersRepository,PublisherRepository>();
            

            return builder.Build();
        }
    }
}
