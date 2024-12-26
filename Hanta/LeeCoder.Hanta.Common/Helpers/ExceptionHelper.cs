using LeeCoder.Hanta.Common.Shared.Enums;
using LeeCoder.Hanta.Common.Shared.Extensions;

namespace LeeCoder.Hanta.Common.Shared.Helpers;

/// <summary>
/// 예외처리 헬퍼
/// </summary>
public class ExceptionHelper
{
    /// <summary>
    /// 예외처리
    /// </summary>
    public static void ProcessException(Exception e, bool isShowMessage, string message)
    {
        string userMessage = $"{message}\n로그를 확인해 주세요.";

        if (isShowMessage == true)
        {
            //사용자에게 알림
            MessageBox.Show(userMessage);
        }

        //에러로그 적재
        StringBuilder errorLogBuilder = new StringBuilder($"Error Message = [{message}]");

        // 현재 작성중인 예외 객제
        Exception? currentException = e;

        // InnerException이 없을 때 까지 메시지 적재
        while (currentException != null)
        {
            errorLogBuilder.AppendLine($"Exception Message = [{e.Message}]");

            currentException = currentException.InnerException;
        }

        //호출스택 적재
        errorLogBuilder.AppendLine($"Stack Trace = {e.StackTrace}");

        //에러로그 작성
        LogHelper.Write(LogType.Fatal, errorLogBuilder.ToString());
    }
}
