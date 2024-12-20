using LeeCoder.Hanta.Common.Abstract.Serivce;
using LeeCoder.Hanta.Common.Services.Logger;

using LeeCoder.Hanta.Server.ViewModels.Main;

namespace LeeCoder.Hanta.Server.App.Builder;

/// <summary>
/// 의존성주입객체 Ioc 빌더
/// </summary>
public class IocBuilder
{
    /// <summary>
    /// IoC 컨테이너 빌드
    /// </summary>
    public static void Build()
    {
        var services = ConfigureService();

        Ioc.Default.ConfigureServices(services);
    }

    /// <summary>
    /// Service Provider 설정
    /// </summary>
    /// <returns> ServiceProvider </returns>
    private static IServiceProvider ConfigureService()
    {
        var services = new ServiceCollection();

        ////////////////////////////////////////
        // Services
        ////////////////////////////////////////
        {
            services.AddSingleton<ILogService, LogService>();
        }


        ////////////////////////////////////////
        // Window DataContexts
        ////////////////////////////////////////
        {
            services.AddTransient<HantaServerWindowViewModel>();
        }


        ////////////////////////////////////////
        // ContentView DataContexts
        ////////////////////////////////////////
        {

        }

        return services.BuildServiceProvider();
    }
}
