using LeeCoder.Hanta.Client.ViewModels.Login;
using LeeCoder.Hanta.Client.ViewModels.Main;

namespace LeeCoder.Hanta.Client.App.Builder;

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

        }


        ////////////////////////////////////////
        // Window DataContexts
        ////////////////////////////////////////
        {
            services.AddTransient<HantaClientWindowViewModel>();
            services.AddTransient<LoginWindowViewModel>();
        }


        ////////////////////////////////////////
        // ContentView DataContexts
        ////////////////////////////////////////
        {

        }

        return services.BuildServiceProvider();
    }
}
