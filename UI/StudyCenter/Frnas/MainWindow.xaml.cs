using log4net;
using System.Reflection;
using System.Windows;

namespace SecretMadonna.NEMS.UI.Frnas
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainWindow));
        private static int numberIndex = 0;

        public MainWindow()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
        }
        ~MainWindow()
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        #region Event
        private void Window_Activated(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ContextMenuClosing(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ContextMenuOpening(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Deactivated(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_DragLeave(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_DragOver(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GotStylusCapture(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_GotTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsStylusCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsStylusCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsStylusDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LayoutUpdated(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LocationChanged(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LostStylusCapture(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_LostTouchCapture(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationBoundaryFeedback(object sender, System.Windows.Input.ManipulationBoundaryFeedbackEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationInertiaStarting(object sender, System.Windows.Input.ManipulationInertiaStartingEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ManipulationStarting(object sender, System.Windows.Input.ManipulationStartingEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            var thisObj = this;
        }

        private void Window_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 在鼠标指针位于此元素上并且移动鼠标指针时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewDragEnter(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewDragLeave(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewDragOver(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewDrop(object sender, DragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 在鼠标指针位于此元素上并且移动鼠标指针时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusDown(object sender, System.Windows.Input.StylusDownEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusInAirMove(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusInRange(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusMove(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewStylusUp(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewTouchMove(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_PreviewTouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 当请求显示光标时发生。 每次鼠标指针移至新位置时都会在一个元素上引发此事件，这意味着光标对象可能需要根据其新位置进行更改。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_QueryCursor(object sender, System.Windows.Input.QueryCursorEventArgs e)
        {
            //logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_SourceInitialized(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusButtonDown(object sender, System.Windows.Input.StylusButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusButtonUp(object sender, System.Windows.Input.StylusButtonEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusDown(object sender, System.Windows.Input.StylusDownEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusEnter(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusInAirMove(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusInRange(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusLeave(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusMove(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusOutOfRange(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusSystemGesture(object sender, System.Windows.Input.StylusSystemGestureEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StylusUp(object sender, System.Windows.Input.StylusEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ToolTipClosing(object sender, System.Windows.Controls.ToolTipEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_ToolTipOpening(object sender, System.Windows.Controls.ToolTipEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TouchEnter(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TouchLeave(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TouchMove(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            logger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        #endregion
    }
}
