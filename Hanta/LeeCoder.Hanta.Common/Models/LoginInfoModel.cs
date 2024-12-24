namespace LeeCoder.Hanta.Common.Shared.Models;

/// <summary>
/// 로그인 정보 모델
/// </summary>
public partial class LoginInfoModel : EncryptPasswordModel
{
    /// <summary>
    /// 유저 아이디
    /// </summary>
    [ObservableProperty]
    private string _userID = string.Empty;
}
