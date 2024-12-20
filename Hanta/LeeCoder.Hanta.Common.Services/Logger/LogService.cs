using LeeCoder.Hanta.Common.Abstract.Serivce;
using LeeCoder.Hanta.Common.Shared.Enums;

namespace LeeCoder.Hanta.Common.Services.Logger;

/// <summary>
/// 로그작성 서비스
/// </summary>
public class LogService : ILogService
{
    #region :: Constructor ::

    /// <summary>
    /// 생성자
    /// </summary>
    public LogService() => BuildSerilLog();

    #endregion


    #region :: Properties ::

    #endregion


    #region :: Methods ::

    /// <summary>
    /// 로그 설정
    /// </summary>
    private void BuildSerilLog()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("Logs\\ClientLog.txt")
            .CreateLogger();
    }

    /// <summary>
    /// 로그 작성
    /// </summary>
    /// <param name="type"   > 로그 타입 </param>
    /// <param name="message"> 로그 내용 </param>
    public void Write(LogType type, string message)
    {
        switch(type)
        {
            case LogType.Normal:   //일반
                Log.Information(message);
                break;

            case LogType.Warning:  //경고
                Log.Warning(message);
                break;

            case LogType.Error:    //오류
                Log.Error(message);
                break;

            case LogType.Fatal:   //예외
                Log.Fatal(message);
                break;

            default:
                return;
        }
    }

    #endregion
}
