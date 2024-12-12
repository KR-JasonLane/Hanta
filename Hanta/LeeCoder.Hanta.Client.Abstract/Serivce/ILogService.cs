using LeeCoder.Hanta.Common.Enums;

namespace LeeCoder.Hanta.Client.Abstract.Serivce;

/// <summary>
/// 로그작성 서비스 추상화
/// </summary>
public interface ILogService
{
    /// <summary>
    /// 로그 작성
    /// </summary>
    /// <param name="type"   > 로그 타입 </param>
    /// <param name="message"> 로그 내용 </param>
    void Write(LogType type, string message);
}
