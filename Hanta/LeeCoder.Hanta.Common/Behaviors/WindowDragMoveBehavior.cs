namespace LeeCoder.Hanta.Common.Shared.Behaviors;

/// <summary>
/// 윈도우 드래그무브 구현
/// </summary>
public class WindowDragMoveBehavior : Behavior<FrameworkElement>
{
    #region :: DP ::

    // Window를 바인딩할 DependencyProperty 정의
    public static readonly DependencyProperty TargetWindowProperty = DependencyProperty.Register(
            nameof(TargetWindow),
            typeof(Window),
            typeof(WindowDragMoveBehavior),
            new PropertyMetadata(null));

    public Window TargetWindow
    {
        get => (Window)GetValue(TargetWindowProperty);
        set => SetValue(TargetWindowProperty, value);
    }

    #endregion

    #region :: Override Methods ::

    /// <summary>
    /// 활성화
    /// </summary>
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.MouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
    }

    /// <summary>
    /// 비활성화
    /// </summary>
    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.MouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
    }

    #endregion

    #region :: Events ::

    /// <summary>
    /// 마우스 좌측클릭 DragMove 실행
    /// </summary>
    /// <param name="sender"> 호출자 파라미터 </param>
    /// <param name="e"     > 이벤트 파라미터 </param>
    private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            TargetWindow.DragMove();
        }
    }

    #endregion
}
