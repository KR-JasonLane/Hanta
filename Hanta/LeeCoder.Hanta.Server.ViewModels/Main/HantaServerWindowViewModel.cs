using CommunityToolkit.Mvvm.Input;
using LeeCoder.Hanta.Common.Abstract.Service;
using LeeCoder.Hanta.Server.ViewModels.Base;

namespace LeeCoder.Hanta.Server.ViewModels.Main;

/// <summary>
/// 한타 메인 윈도우 데이터 콘텍스트
/// </summary>
public partial class HantaServerWindowViewModel : HantaServerViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public HantaServerWindowViewModel(IMainWindowManagementService mainWindowManagementService)
    {
        ////////////////////////////////////////
        // 서비스 등록
        ////////////////////////////////////////
        {
            _mainWindowManagementService = mainWindowManagementService;
        }
    }

    #endregion


    #region :: Services ::

    /// <summary>
    /// 메인윈도우 관리 서비스
    /// </summary>
    private readonly IMainWindowManagementService _mainWindowManagementService;

    #endregion


    #region :: Properties ::

    #endregion


    #region :: Methods ::

    #endregion

    #region :: Commands ::

    /// <summary>
    /// 최소화
    /// </summary>
    [RelayCommand]
    private void Minimize() => _mainWindowManagementService.Minimize();

    /// <summary>
    /// 복원/최대화
    /// </summary>
    [RelayCommand]
    private void NormalOrMaximize() => _mainWindowManagementService.NormalOrMaximize();

    /// <summary>
    /// 창 닫기
    /// </summary>
    [RelayCommand]
    private void Close() => _mainWindowManagementService.Close();

    #endregion
}
