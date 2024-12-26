using LeeCoder.Hanta.Common.Shared.Enums;

namespace LeeCoder.Hanta.Common.Shared.Helpers;

/// <summary>
/// 로그작성 헬퍼
/// </summary>
public class LogHelper
{
    #region Readonly Properties

    /// <summary>
    /// 로거 빌드 여부 판단
    /// </summary>
    private static bool _isBuildedLogger = false;

    #endregion

    #region Static Methods

    /// <summary>
    /// 로그 설정
    /// </summary>
    private static void BuildSerilLog()
    {
        ////////////////////////////////////////
        // 로거 빌드
        ////////////////////////////////////////
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File($"Logs\\{DateTime.Now.ToString(DateTimeFormatHelper.YearMonthDayBySnake)}.txt")
                .CreateLogger();
        }

        ////////////////////////////////////////
        // 빌드플래그 ON
        ////////////////////////////////////////
        {
            _isBuildedLogger = true;
        }
    }

    /// <summary>
    /// 로그 작성
    /// </summary>
    /// <param name="type"   > 로그 타입 </param>
    /// <param name="message"> 로그 내용 </param>
    public static void Write(LogType type, string message)
    {
        ////////////////////////////////////////
        // 빌드플래그 검사 후 필요 시 빌드
        ////////////////////////////////////////
        {
            if (_isBuildedLogger == false) BuildSerilLog();
        }


        ////////////////////////////////////////
        // 타입에 따라 로그 작성
        ////////////////////////////////////////
        {
            switch (type)
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
    }

    #endregion
}
