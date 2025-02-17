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
            //builder.Services.AddSingleton<PersoonPage>();
            builder.Services.AddSingleton<VragenlijstPage>();


            //Viewmodel
            //builder.Services.AddSingleton<PersoonViewModel>();
            builder.Services.AddSingleton<VragenlijstViewModel>();
                
           

            return builder.Build();
        }
    }
}
