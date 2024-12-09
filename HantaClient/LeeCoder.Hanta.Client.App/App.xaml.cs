using LeeCoder.Hanta.Client.App.Builder;

using LeeCoder.Hanta.Client.ViewModels.Main;
using LeeCoder.Hanta.Client.Views.Main;

namespace LeeCoder.Hanta.Client.App;

/// <summary>
/// 한타 클라이언트
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// 클라이언트 시작지점
    /// </summary>
	protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ////////////////////////////////////////
        // 의존성 주입 객체 빌드
        ////////////////////////////////////////
        {
            IocBuilder.Build();
        }


        ////////////////////////////////////////
        // 한타 메인 윈도우 세팅
        ////////////////////////////////////////
        {
            this.MainWindow = new ShellWindowView() { DataContext = Ioc.Default.GetService<ShellWindowViewModel>() };
            this.MainWindow.Show();
        }
    }
}
