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
            builder.Services.AddSingleton<PersoonPage>();
            builder.Services.AddSingleton<LabelsPage>();
            builder.Services.AddSingleton<StackLayoutPage>();
            builder.Services.AddSingleton<NaamTonenPage>();


            //Viewmodel
            builder.Services.AddSingleton<PersoonViewModel>();
            builder.Services.AddSingleton<LabelViewModel>();
            builder.Services.AddSingleton<StackLayoutViewModel>();
            builder.Services.AddSingleton<NaamTonenViewModel>();

            return builder.Build();
        }
    }
}
