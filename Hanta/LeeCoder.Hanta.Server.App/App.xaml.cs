using LeeCoder.Hanta.Server.App.Builder;
using LeeCoder.Hanta.Server.ViewModels.Main;
using LeeCoder.Hanta.Common.Views.Main;
using LeeCoder.Hanta.Common.Abstract.Serivce;
using LeeCoder.Hanta.Common.Shared.Enums;
using LeeCoder.Hanta.Common.Services.Logger;

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

        //로그서비스 객체 호출
        ILogService logService = Ioc.Default.GetService<ILogService>()!;

        //시작로그 작성
        logService.Write(LogType.Normal, ":: 한타 서버 프로그램 시작 ::");


        //메인윈도우 호출
        ShowMainWindow();
    }

    /// <summary>
    /// 메인윈도우 호출
    /// </summary>
    private void ShowMainWindow()
    {
        this.MainWindow = new HantaWindowView() { DataContext = Ioc.Default.GetService<HantaServerWindowViewModel>() };

        MainWindow.Show();
    }
}
