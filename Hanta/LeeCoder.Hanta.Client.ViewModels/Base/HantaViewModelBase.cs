using LeeCoder.Hanta.Client.Abstract.Serivce;
using LeeCoder.Hanta.Client.Abstract.ViewModel;

namespace LeeCoder.Hanta.Client.ViewModels.Base;

/// <summary>
/// 한타 뷰모델 상속클래스
/// </summary>
public abstract partial class HantaViewModelBase : ObservableRecipient, IHantaViewModel
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public HantaViewModelBase(ILogService logService)
    {
        ////////////////////////////////////////
        // 서비스 의존성 주입
        ////////////////////////////////////////
        {
            _logService = logService;
        }
    }

    #endregion


    #region :: Properties ::

    /// <summary>
    /// 로그작성 서비스
    /// </summary>
    protected ILogService _logService;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 메모리 해제
    /// 구독된 메신저를 모두 해제한다.
    /// </summary>
    public void UnRegisterMessages() => WeakReferenceMessenger.Default.UnregisterAll(this);

    #endregion

    #region :: Commands ::

    #endregion
}
