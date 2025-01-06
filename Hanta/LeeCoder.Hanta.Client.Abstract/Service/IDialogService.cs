using LeeCoder.Hanta.Client.Utils.Enums;

namespace LeeCoder.Hanta.Client.Abstract.Service;

/// <summary>
/// 다이얼로그 서비스 추상화 인터페이스
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// 다이얼로그 Show
    /// </summary>
    /// <param name="type"   > 표현할 다이얼로그 형태의 타입          </param>
    /// <param name="message"> 다이얼로그에 띄울 메시지(기본은 empty) </param>
    bool ShowDialog(DialogContentType type, string message = "");

    /// <summary>
    /// 다이얼로그의 형태를 변경
    /// </summary>
    /// <param name="type"   > 변경할 다이얼로그 형태의 타입          </param>
    /// <param name="message"> 다이얼로그에 띄울 메시지(기본은 empty) </param>
    void ChangeDialogContent(DialogContentType type, string message = "");
}
