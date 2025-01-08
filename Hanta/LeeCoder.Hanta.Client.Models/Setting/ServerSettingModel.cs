namespace LeeCoder.Hanta.Client.Models.Setting;

/// <summary>
/// 서버설정 모델
/// </summary>
public partial class ServerSettingModel : ObservableObject
{
    /// <summary>
    /// 서버 IP
    /// </summary>
    [ObservableProperty]
    private string? _iP;

    /// <summary>
    /// 서버 포트
    /// </summary>
    [ObservableProperty]
    private string? _port;
}
