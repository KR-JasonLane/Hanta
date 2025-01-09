using LeeCoder.Hanta.Client.Utils.Messenger.Message;
using LeeCoder.Hanta.Client.Utils.Messenger.Parameter;
using LeeCoder.Hanta.Client.ViewModels.Base;
using LeeCoder.Hanta.Common.Abstract.ViewModel;

namespace LeeCoder.Hanta.Client.ViewModels.Dialog;

/// <summary>
/// 다이얼로그 껍데기 뷰 DataContext
/// </summary>
public partial class DialogShellViewModel : HantaClientViewModelBase
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public DialogShellViewModel() => RegisterMessages(); 

    #endregion

    #region :: Services ::

    #endregion

    #region :: Properties ::

    /// <summary>
    /// 다이얼로그 내용
    /// </summary>
    [ObservableProperty]
    public IHantaViewModel? _dialogContent;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 메시지 구독
    /// </summary>
    private void RegisterMessages()
    {
        //Content 변경 메시지 구독
        WeakReferenceMessenger.Default.Register<ChangeDialogContentMessage>(this, (sender, message) => ReceiveChangeDialogContentMessage(message.Value));
    }

    /// <summary>
    /// 다이얼로그 변경 메시지 처리
    /// </summary>
    /// <param name="param"> 메시지 파라미터 </param>
    private void ReceiveChangeDialogContentMessage(ChangeDialogContentParameter param)
    {
        //파라미터 유효성검사
        if (param.CanUsable() == false)
        {
            throw new NullReferenceException($"{nameof(ChangeDialogContentParameter)}파라미터를 사용할 수 없습니다.\n파라미터 상태 = [{param}]\n타입 = [{param?.ContentType}]\n메시지 = [{param?.Message}]\nContent Instance = [{param?.Content}]");
        }

        //Content 적용
        this.DialogContent = param.Content;
    }

    /// <summary>
    /// 메시지 구독 해제 시 
    /// Content요소의 메시지도 구독 해제
    /// </summary>
    public override void UnRegisterMessages()
    {
        base.UnRegisterMessages();

        if(DialogContent != null) DialogContent.UnRegisterMessages();
    }

    #endregion

    #region :: Commands ::

    #endregion
}
