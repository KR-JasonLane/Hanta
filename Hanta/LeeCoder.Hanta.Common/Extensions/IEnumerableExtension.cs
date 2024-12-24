namespace LeeCoder.Hanta.Common.Shared.Extensions;

/// <summary>
/// IEnumerable 객체 확장매서드 정의
/// </summary>
public static class IEnumerableExtension
{
    /// <summary>
    /// NULL이거나 비어있는지 확인
    /// </summary>
    /// <typeparam name="T" > 요소 타입 </typeparam>
    /// <param name="target"> 확인 대상 </param>
    /// <returns> 결과반환 </returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? target)
    {
        return target == null || target.Count() == 0;
    }
}
