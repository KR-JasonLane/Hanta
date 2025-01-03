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
    /// <param name="type"> 표현할 다이얼로그 형태의 타입 </param>
    void ShowDialog(DialogContentType type);

    /// <summary>
    /// 다이얼로그의 형태를 변경
    /// </summary>
    /// <param name="type"> 변경할 다이얼로그 형태의 타입 </param>
    void ChangeDialogContent(DialogContentType type);

    /// <summary>
    /// 다이얼로그 닫기
    /// </summary>
    /// <returns> OK = true, Cancel = false </returns>
    bool CloseDialog();
}
