namespace LeeCoder.Hanta.Common.Abstract.ViewModel;

/// <summary>
/// 메모리 정리가 가능한 한타뷰모델 인터페이스
/// </summary>
public interface IHantaViewModel
{
    /// <summary>
    /// 메시지 구독해제
    /// </summary>
    void UnRegisterMessages();
}
