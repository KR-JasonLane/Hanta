using LeeCoder.Hanta.Client.ViewModels.Base;
using LeeCoder.Hanta.Common.Shared.Models;
using LeeCoder.Hanta.Common.Abstract.Serivce;

namespace LeeCoder.Hanta.Client.ViewModels.Login;

public partial class LoginWindowViewModel : HantaClientViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public LoginWindowViewModel(ILogService logService) : base(logService)
    {
        LoginModel = new LoginSettingModel();
    }

    #endregion


    #region :: Properties ::

    /// <summary>
    /// 유저 아이디
    /// </summary>
    [ObservableProperty]
    private LoginSettingModel _loginModel;

    #endregion

    #region :: Methods ::

    #endregion

    #region :: Commands ::

    /// <summary>
    /// 서버설정 열기
    /// </summary>
    [RelayCommand]
    private void OpenServerConfig()
    {

    }

    /// <summary>
    /// 창닫기
    /// </summary>
    [RelayCommand]
    private void Close()
    {

    }

    /// <summary>
    /// 서버로 비밀번호 초기화 요청
    /// </summary>
    [RelayCommand]
    private void RequestInitPassword()
    {

    }

    /// <summary>
    /// 서버로 로그인 요청
    /// </summary>
    [RelayCommand]
    private void Login()
    {

    }

    /// <summary>
    /// 서버로 가입요청
    /// </summary>
    [RelayCommand]
    private void RequestRegister()
    {

    }

    #endregion
}
