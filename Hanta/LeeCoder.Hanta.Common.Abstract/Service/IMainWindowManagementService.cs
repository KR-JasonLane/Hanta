namespace LeeCoder.Hanta.Common.Abstract.Service;

/// <summary>
/// 메인윈도우 관리 서비스 추상화 인터페이스
/// </summary>
public interface IMainWindowManagementService
{
    /// <summary>
    /// 현재 메인윈도우가 최대화 상태면 복원,
    /// 기본상태면 최대화로 변경함.
    /// </summary>
    void NormalOrMaximize();

    /// <summary>
    /// 창 최소화
    /// </summary>
    void Minimize();

    /// <summary>
    /// 창 닫기
    /// </summary>
    void Close();
}
