using LeeCoder.Hanta.Server.App.Builder;
using LeeCoder.Hanta.Server.ViewModels.Main;

using LeeCoder.Hanta.Common.Views.Main;
using LeeCoder.Hanta.Common.Shared.Enums;
using LeeCoder.Hanta.Common.Shared.Helpers;

namespace LeeCoder.Hanta.Server.App;

/// <summary>
/// 한타 서버
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// 프로그램 시작지점
    /// </summary>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ////////////////////////////////////////
        // 의존성주입 객체 빌드
        ////////////////////////////////////////
        {
            IocBuilder.Build();
        }

        ////////////////////////////////////////
        // 시작로그 작성
        ////////////////////////////////////////
        {
            LogHelper.Write(LogType.Normal, ":: 한타 서버 프로그램 시작 ::");
        }

        ////////////////////////////////////////
        // 메인윈도우 호출
        ////////////////////////////////////////
        {
            ShowMainWindow();
        }
    }

    /// <summary>
    /// 메인윈도우 호출
    /// </summary>
    private void ShowMainWindow()
    {
        this.MainWindow = new HantaWindowView() { DataContext = Ioc.Default.GetService<HantaServerWindowViewModel>() };
        this.MainWindow.Show();
    }

    /// <summary>
    /// 전역 예외처리
    /// </summary>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        ExceptionHelper.ProcessException(e.Exception, true, "시스템에 치명적인 오류가 발생했습니다.");
    }
}
