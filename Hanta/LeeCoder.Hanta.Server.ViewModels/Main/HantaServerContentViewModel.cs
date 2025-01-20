using LeeCoder.Hanta.Common.Abstract.ViewModel;
using LeeCoder.Hanta.Server.ViewModels.Base;

namespace LeeCoder.Hanta.Server.ViewModels.Main;

public partial class HantaServerContentViewModel : HantaServerViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public HantaServerContentViewModel()
    {

    }

    #endregion

    #region :: Services ::

    #endregion

    #region :: Properties ::

    [ObservableProperty]
    private IHantaViewModel? _pluginContent;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 메시지 구독 해제 시 
    /// Content요소의 메시지도 구독 해제
    /// </summary>
    public override void UnRegisterMessages()
    {
        base.UnRegisterMessages();

        if(PluginContent != null) PluginContent.UnRegisterMessages();
    }

    #endregion

    #region :: Commands ::

    #endregion
}
