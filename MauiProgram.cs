using Microsoft.Extensions.Logging;

namespace FinalExamCambpellJon
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
                    fonts.AddFont("AquilineTwo.ttf", "AquilineTwo");
                    fonts.AddFont("harryp.ttf", "HarryP");
                    fonts.AddFont("parryhotter.ttf", "ParryHotter");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
