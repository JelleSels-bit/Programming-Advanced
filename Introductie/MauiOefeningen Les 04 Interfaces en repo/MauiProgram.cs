using MauiOefeningen.Data.Repositories;
using MauiOefeningen.viewmodel;
using MauiOefeningen.Views;
using Microsoft.Extensions.Logging;

namespace MauiOefeningen
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
            //Views
          
            builder.Services.AddSingleton<NamenPage1>();
            builder.Services.AddSingleton<WerknemerPage>();
            builder.Services.AddSingleton<GetallenPage>();
            builder.Services.AddSingleton<FactuurPage>();
            builder.Services.AddSingleton<GamePage>();



            //Viewmodel
            //builder.Services.AddSingleton<PersoonViewModel>();
            builder.Services.AddSingleton<NamenViewModel>();
            builder.Services.AddSingleton<WerknemerViewModel>();
            builder.Services.AddSingleton<GetallenViewModel>();
            builder.Services.AddSingleton<FactuurViewModel>();
            builder.Services.AddSingleton<GameViewModel>();


            //Interfaces
            builder.Services.AddSingleton<IWerknemerRepository,WerknemerRepository>();
            builder.Services.AddSingleton<IFunctieRepository, FunctieRepository>();
            builder.Services.AddSingleton<IGameRepository, GameRepository>();

            return builder.Build();
        }
    }
}
