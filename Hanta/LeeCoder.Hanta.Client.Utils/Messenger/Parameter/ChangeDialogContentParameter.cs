using LeeCoder.Hanta.Client.Utils.Enums;
using LeeCoder.Hanta.Common.Abstract.ViewModel;

namespace LeeCoder.Hanta.Client.Utils.Messenger.Parameter;

/// <summary>
/// 다이얼로그 Content 변경 파라미터
/// </summary>
public class ChangeDialogContentParameter
{
    /// <summary>
    /// 메시지가 필요한 다이얼로그일 시 사용
    /// </summary>
    public string? Message;

    /// <summary>
    /// Content
    /// </summary>
    public IHantaViewModel? Content;

    /// <summary>
    /// 다이얼로그 Content 타입 정의
    /// </summary>
    public DialogContentType ContentType;

    /// <summary>
    /// 사용 가능한 상태인지 검사
    /// </summary>
    /// <returns> 사용가능여부 </returns>
    public bool CanUsable()
    {
        bool canUsable = (Content != null);

        //TODO : 메시지 타입에 따라 canUsable 변수에 OR연산으로, ContentType에 따른 메시지 IsNullOrEmpty 결과도 추가.

        return canUsable;
    }
}
