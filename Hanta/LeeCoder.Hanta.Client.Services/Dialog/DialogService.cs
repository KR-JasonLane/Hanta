using LeeCoder.Hanta.Client.Abstract.Service;
using LeeCoder.Hanta.Client.Utils.Enums;

namespace LeeCoder.Hanta.Client.Services.Dialog;

/// <summary>
/// 다이얼로그 서비스 구현
/// </summary>
public class DialogService : IDialogService
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public DialogService()
    {
        InitializeService();
    }

    #endregion


    #region :: Properties ::

    /// <summary>
    /// 현재 나타내고 있는 다이얼로그의 타입
    /// </summary>
    private DialogContentType _currentType;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 다이얼로그 Show
    /// </summary>
    /// <param name="type"> 표현할 다이얼로그 형태의 타입 </param>
    public void ShowDialog(DialogContentType type)
    {
        if(type == DialogContentType.Initialize)
        {
            throw new ArgumentException($"{type.ToString()}은 ShowDialog의 초기값이 될 수 없습니다.");
        }
    }

    /// <summary>
    /// 다이얼로그의 형태를 변경
    /// </summary>
    /// <param name="type"> 변경할 다이얼로그 형태의 타입 </param>
    public void ChangeDialogContent(DialogContentType type)
    {
        //현재 상태와 같으면 변경하지 않음.
        if (type == _currentType) return;
    }

    /// <summary>
    /// 다이얼로그 닫기
    /// </summary>
    /// <returns> OK = true, Cancel = false </returns>
    public bool CloseDialog()
    {
        //서비스 초기화
        InitializeService();

        return true; //임시
    }

    /// <summary>
    /// 서비스 상태 초기화
    /// </summary>
    private void InitializeService() => _currentType = DialogContentType.Initialize;

    #endregion
}
