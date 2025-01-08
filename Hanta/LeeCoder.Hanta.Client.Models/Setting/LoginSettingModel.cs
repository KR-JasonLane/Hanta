using LeeCoder.Hanta.Common.Shared.Models;

namespace LeeCoder.Hanta.Client.Models.Setting;

/// <summary>
/// 로그인 설정 모델
/// </summary>
public partial class LoginSettingModel : LoginInfoModel
{
    /// <summary>
    /// 아이디 저장 여부
    /// </summary>
    [ObservableProperty]
    private bool _isSaveUserID = false;
}
