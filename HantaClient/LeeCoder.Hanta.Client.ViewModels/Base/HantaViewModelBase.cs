using LeeCoder.Hanta.Client.Abstract.ViewModel;

namespace LeeCoder.Hanta.Client.ViewModels.Base;

/// <summary>
/// 한타 뷰모델 상속클래스
/// </summary>
public abstract partial class HantaViewModelBase : ObservableRecipient, IHantaViewModel
{
    #region :: Constructor ::

    #endregion


    #region :: Properties ::

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 메모리 해제
    /// 구독된 메신저를 모두 해제한다.
    /// </summary>
    public void Dispose() => WeakReferenceMessenger.Default.UnregisterAll(this);

    #endregion

    #region :: Commands ::

    #endregion
}
