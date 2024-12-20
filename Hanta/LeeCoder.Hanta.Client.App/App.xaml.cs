using LeeCoder.Hanta.Common.Shared.Enums;
using LeeCoder.Hanta.Common.Abstract.Serivce;

using LeeCoder.Hanta.Client.App.Builder;
using LeeCoder.Hanta.Client.Views.Login;
using LeeCoder.Hanta.Client.ViewModels.Login;

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

        //의존성주입 객체 빌드
        IocBuilder.Build();
                
        //로그서비스 객체 호출
        ILogService logService = Ioc.Default.GetService<ILogService>()!;

        //시작로그 작성
        logService.Write(LogType.Normal, ":: 한타 클라이언트 프로그램 시작 ::");

        //로그인에 성공하지 못하면 프로그램 종료
        if(Login() == false)
        {
            Process.GetCurrentProcess().Kill();
        }
    }

    /// <summary>
    /// 로그인
    /// </summary>
    /// <returns> 로그인 성공여부 </returns>
    private bool Login()
    {
        //로그인 뷰 띄워주기
        var loginView = new LoginWindowView() { DataContext = Ioc.Default.GetService<LoginWindowViewModel>() };

        //결과 반환
        return loginView.ShowDialog() ?? false;
    }
}
