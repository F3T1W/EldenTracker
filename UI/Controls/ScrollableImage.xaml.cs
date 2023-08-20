using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Foundation;

namespace EldenTracker.UI.Controls
{
    public sealed partial class ScrollableImage : UserControl
    {
        private Point _startPoint;

        private Point _startOffset;
        
        public ScrollableImage()
        {
            InitializeComponent();
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Capture pointer and store initial position
            ImageView.CapturePointer(e.Pointer);
            _startPoint = e.GetCurrentPoint(ImageView).Position;
            _startOffset = new Point(Scroll.HorizontalOffset, Scroll.VerticalOffset);
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var currentPoint = e.GetCurrentPoint(ImageView);
            if (currentPoint.Properties.IsLeftButtonPressed == false)
            {
                return;
            }
            // Calculate new offset based on pointer movement
            var currentPosition = currentPoint.Position;
            var offsetX = _startOffset.X + (_startPoint.X - currentPosition.X);
            var offsetY = _startOffset.Y + (_startPoint.Y - currentPosition.Y);

            if (offsetX < 0 || offsetY < 0)
            {
                return;
            }

            // Update the ScrollViewer's offset
            Scroll.ChangeView(offsetX, offsetY, null, false);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            // Release the captured pointer
            ImageView.ReleasePointerCapture(e.Pointer);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // This event is raised when the image has been measured and arranged
            var horizontalOffset = (ImageView.ActualWidth - Scroll.ActualWidth) / 3;
            var verticalOffset = (ImageView.ActualHeight - Scroll.ActualHeight) / 2;

            // Set the initial scroll position
            Scroll.ChangeView(horizontalOffset, verticalOffset, null);

            // Unsubscribe from the event, as we only need to do this once
            ImageView.SizeChanged -= OnSizeChanged;
        }
    }
}
