namespace LeeCoder.Hanta.Common.Models;

/// <summary>
/// 로그인 정보 모델
/// </summary>
public partial class LoginInfoModel : ObservableObject
{
    /// <summary>
    /// 유저 아이디
    /// </summary>
    [ObservableProperty]
    private string _userID = string.Empty;

    /// <summary>
    /// 유저 패스워드
    /// </summary>
    [ObservableProperty]
    private string _userPW = string.Empty;

    /// <summary>
    /// 아이디 저장 여부
    /// </summary>
    [ObservableProperty]
    private bool _isSaveUserID = false;
}
