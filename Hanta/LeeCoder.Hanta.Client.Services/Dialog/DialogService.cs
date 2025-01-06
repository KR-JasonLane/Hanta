using LeeCoder.Hanta.Client.Abstract.Service;

using LeeCoder.Hanta.Client.Utils.Enums;
using LeeCoder.Hanta.Client.Utils.Messenger.Message;
using LeeCoder.Hanta.Client.Utils.Messenger.Parameter;

using LeeCoder.Hanta.Client.ViewModels.Dialog;

using LeeCoder.Hanta.Client.Views.Dialog;
using LeeCoder.Hanta.Common.Abstract.ViewModel;
using LeeCoder.Hanta.Common.Shared.Enums;

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
        ////////////////////////////////////////
        // 서비스 초기화
        ////////////////////////////////////////
        {
            InitializeService();
        }
    }

    #endregion


    #region :: Properties ::

    /// <summary>
    /// 현재 나타내고 있는 다이얼로그의 타입
    /// </summary>
    private DialogContentType _currentType;

    /// <summary>
    /// 현재 다이얼로그 Context
    /// </summary>
    private IHantaViewModel? _currentDataContext;

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 다이얼로그 Show
    /// </summary>
    /// <param name="type"> 표현할 다이얼로그 형태의 타입 </param>
    public bool ShowDialog(DialogContentType type, string message = "")
    {
        //타입검사
        if(type == DialogContentType.Initialize)
        {
            throw new ArgumentException($"{type.ToString()}은 ShowDialog의 초기값이 될 수 없습니다.");
        }

        //다이얼로그 뷰모델 생성
        IHantaViewModel dialogViewModel = new DialogShellViewModel();

        //생성한 뷰모델 기억
        _currentDataContext = dialogViewModel;

        //다이얼로그 뷰 객체 생성
        object? dialogView = new DialogShellView() { DataContext = dialogViewModel };

        //Content 변경 메시지 전송
        SendChangeDialogContentMessage(type, message);

        //다이얼로그 호출
        object? result = DialogHost.Show(dialogView, DialogHostType.LoginWindowDialogHost.ToString());

        //서비스 초기화
        InitializeService();

        //결과 반환
        return result is true;
    }

    /// <summary>
    /// 다이얼로그의 형태를 변경
    /// </summary>
    /// <param name="type"> 변경할 다이얼로그 형태의 타입 </param>
    public void ChangeDialogContent(DialogContentType type, string message = "")
    {
        //현재 상태와 같으면 변경하지 않음.
        if (type == _currentType) return;
    }

    /// <summary>
    /// 서비스 상태 초기화
    /// </summary>
    private void InitializeService()
    {
        //기억된 DataContext가 있을 경우
        //메시지 구독을 모두 풀어준 후 null로 만들어 준다.
        if(_currentDataContext != null)
        {
            _currentDataContext.UnRegisterMessages();
            _currentDataContext = null;
        }

        _currentType = DialogContentType.Initialize;
    }

    /// <summary>
    /// ChangeDialogContentParameter 생성
    /// </summary>
    /// <param name="type"   > 지정할 타입       </param>
    /// <param name="message"> 다이얼로그 메시지 </param>
    /// <returns> 생성된 파라미터 객체 </returns>
    private void SendChangeDialogContentMessage(DialogContentType type, string message)
    {
        //객체 생성
        var msgParam = new ChangeDialogContentParameter();

        //메시지, 타입 부여
        msgParam.Message     = message;
        msgParam.ContentType = type   ;

        //타입별 Content 지정
        msgParam.Content = type switch
        {
            DialogContentType.ServerConfig => new DialogServerConfigViewModel(),
            _ => null
        };

        //메시지 전송
        WeakReferenceMessenger.Default.Send(new ChangeDialogContentMessage(msgParam));
    }

    #endregion
}
