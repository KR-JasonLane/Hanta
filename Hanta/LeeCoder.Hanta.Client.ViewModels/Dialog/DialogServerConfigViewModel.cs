using LeeCoder.Hanta.Client.Models.Setting;

using LeeCoder.Hanta.Client.ViewModels.Base;

using LeeCoder.Hanta.Common.Shared.Helpers;

namespace LeeCoder.Hanta.Client.ViewModels.Dialog;

/// <summary>
/// 다이얼로그 서버 설정 뷰 데이터 콘텍스트
/// </summary>
public partial class DialogServerConfigViewModel : HantaClientViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public DialogServerConfigViewModel()
    {
        ////////////////////////////////////////
        // 서버설정 로드
        ////////////////////////////////////////
        {
            ServerModel = SettingFileHelper.GetSettingModel<ServerSettingModel>();
        }
    }

    #endregion

    #region :: Services ::

    #endregion

    #region :: Properties ::

    /// <summary>
    /// 서버설정 모델
    /// </summary>
    [ObservableProperty]
    private ServerSettingModel _serverModel;

    #endregion

    #region :: Methods ::

    #endregion

    #region :: Commands ::

    /// <summary>
    /// 다이얼로그 닫기
    /// </summary>
    [RelayCommand]
    private void Close()
    {

    }

    /// <summary>
    /// 서버 연결 테스트
    /// </summary>
    [RelayCommand]
    private void ConnectionTest()
    {

    }

    /// <summary>
    /// 설정 저장 후 닫기
    /// </summary>
    [RelayCommand]
    private void Save()
    {

    }

    #endregion
}
