using LeeCoder.Hanta.Client.ViewModels.Base;
using LeeCoder.Hanta.Common.Shared.Enums;
using LeeCoder.Hanta.Common.Shared.Helpers;
using LeeCoder.Hanta.Common.Shared.Models;

namespace LeeCoder.Hanta.Client.ViewModels.Login;

public partial class LoginWindowViewModel : HantaClientViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public LoginWindowViewModel()
    {
        ////////////////////////////////////////
        // 객체 초기화
        ////////////////////////////////////////
        {
            DialogHostType = DialogHostType.LoginWindowDialogHost;
        }


        ////////////////////////////////////////
        // 사용자 설정 로드
        ////////////////////////////////////////
        {
            LoginModel = SettingFileHelper.GetSettingModel<LoginSettingModel>();
        }
    }

    #endregion


    #region :: Properties ::

    /// <summary>
    /// 유저 로그인 설정
    /// </summary>
    [ObservableProperty]
    private LoginSettingModel _loginModel;

    [ObservableProperty]
    private DialogHostType _dialogHostType;

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
        bool isSuccessLogin = false;

        ////////////////////////////////////////
        // TODO : 서버로 로그인 요청
        ////////////////////////////////////////
        {

        }

        ////////////////////////////////////////
        // 로그인 성공 시 로그인 정보 저장.
        ////////////////////////////////////////
        {
            if(isSuccessLogin == true) SettingFileHelper.SaveSettingModel(LoginModel);
        }
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
