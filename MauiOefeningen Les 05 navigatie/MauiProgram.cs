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
          
            builder.Services.AddSingleton<WerknemerPage>();
            builder.Services.AddSingleton<DetailPage>();
            builder.Services.AddSingleton<PersoonIngevenPage>();
            builder.Services.AddSingleton<PersonenTonenPage>();
            builder.Services.AddSingleton<GetallenDoorgeven1Page>();
            builder.Services.AddSingleton<GetallenDoorgeven2Page>();



            //Viewmodel
            //builder.Services.AddSingleton<PersoonViewModel>();
        
            builder.Services.AddSingleton<WerknemerViewModel>();
            builder.Services.AddSingleton<DetailViewModel>();
            builder.Services.AddSingleton<PersonenIngevenViewModel>();
            builder.Services.AddSingleton<PersoonTonenViewModel>();
            builder.Services.AddSingleton<GetallenDoorGeven1ViewModel>();
            builder.Services.AddSingleton<GetallenDoorGeven2ViewModel>();




            //Interfaces
            builder.Services.AddSingleton<IWerknemerRepository,WerknemerRepository>();
            builder.Services.AddSingleton<IFunctieRepository, FunctieRepository>();
            builder.Services.AddSingleton<IGameRepository, GameRepository>();

            return builder.Build();
        }
    }
}
