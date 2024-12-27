namespace LeeCoder.Hanta.Common.Shared.Converters;

/// <summary>
/// Enum요소의 이름을 문자열로 변경해주는 컨버터
/// </summary>
public class EnumItemNameToStringConverter : IValueConverter
{
    /// <summary>
    /// Enum요소의 이름을 문자열로 변경
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value.GetType().IsEnum)
        {
            return value.ToString() ?? string.Empty;
        }
        return string.Empty;
    }

    /// <summary>
    /// 컨버팅한 값을 원래 값으로 되돌림 (사용하지 않음.)
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException("잘못된 접근입니다.");
    }
}
