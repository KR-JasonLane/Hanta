using LeeCoder.Hanta.Server.App.Builder;
using LeeCoder.Hanta.Server.ViewModels.Main;
using LeeCoder.Hanta.Server.Views.Main;

namespace LeeCoder.Hanta.Server.App;

/// <summary>
/// 한타 서버
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        //의존성주입 객체 빌드
        IocBuilder.Build();

        //메인윈도우 호출
        ShowMainWindow();
    }

    /// <summary>
    /// 메인윈도우 호출
    /// </summary>
    private void ShowMainWindow()
    {
        this.MainWindow = new HantaWindowView() { DataContext = Ioc.Default.GetService<HantaWindowViewModel>() };

        MainWindow.Show();
    }
}
