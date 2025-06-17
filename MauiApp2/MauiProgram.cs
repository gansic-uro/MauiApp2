using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;
using MauiApp2; // 🔥 App 클래스 사용을 위한 네임스페이스
using CommunityToolkit.Maui;

namespace MauiApp2;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>() // ← 여기가 오류 없이 잘 작동해야 함!3
        .ConfigureSyncfusionCore().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        }).UseMauiCommunityToolkit();
        return builder.Build();
    }
}