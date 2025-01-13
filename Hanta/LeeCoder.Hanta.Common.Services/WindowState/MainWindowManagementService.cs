using LeeCoder.Hanta.Common.Abstract.Service;

namespace LeeCoder.Hanta.Common.Services.WindowState;

/// <summary>
/// 메인윈도우 관리 서비스 구현부
/// </summary>
public class MainWindowManagementService : IMainWindowManagementService
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public MainWindowManagementService()
    {
        ////////////////////////////////////////
        // 윈도우 설정
        ////////////////////////////////////////
        {
            _mainWindow = Application.Current.MainWindow;
        }
    }

    #endregion

    #region :: Properties ::

    private readonly Window _mainWindow;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 현재 메인윈도우가 최대화 상태면 복원,
    /// 기본상태면 최대화로 변경함.
    /// </summary>
    public void NormalOrMaximize()
    {
        _mainWindow.WindowState = _mainWindow.WindowState switch
        {
            System.Windows.WindowState.Normal    => System.Windows.WindowState.Maximized,
            System.Windows.WindowState.Maximized => System.Windows.WindowState.Normal   ,
            _                                    => System.Windows.WindowState.Normal
        };
    }

    /// <summary>
    /// 창 최소화
    /// </summary>
    public void Minimize()
    {
        _mainWindow.WindowState = System.Windows.WindowState.Minimized;
    }

    /// <summary>
    /// 창 닫기
    /// </summary>
    public void Close()
    {
        _mainWindow.Close();
    }

    #endregion
}
