﻿using LeeCoder.Hanta.Server.Abstract.ViewModel;

namespace LeeCoder.Hanta.Server.ViewModels.Base;

/// <summary>
/// 한타 뷰모델 상속클래스
/// </summary>
public partial class HantaViewModelBase : ObservableRecipient, IHantaViewModel
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public HantaViewModelBase()
    {

    }

    #endregion

    #region :: Properties ::

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
