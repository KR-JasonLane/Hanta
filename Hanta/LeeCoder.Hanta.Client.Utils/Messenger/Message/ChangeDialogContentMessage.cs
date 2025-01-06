using LeeCoder.Hanta.Client.Utils.Messenger.Parameter;

namespace LeeCoder.Hanta.Client.Utils.Messenger.Message;

/// <summary>
/// 다이얼로그 Content변경 메시지
/// </summary>
public class ChangeDialogContentMessage : ValueChangedMessage<ChangeDialogContentParameter>
{
    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="param"> 메시지 파라미터 </param>
    public ChangeDialogContentMessage(ChangeDialogContentParameter param) : base(param) { }
}
