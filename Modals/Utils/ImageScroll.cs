using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace EldenTracker.Modals.Utils 
{ 
    // кринж что это в Utils, поместил сюда просто, чтобы где-то было
    // по факту это custom UserControl (условный ScrollableImage), который просто в XAML размещается
    internal sealed class ImageScroll
    {
        private readonly Image _image;

        private readonly ScrollViewer _scroll;
        
        private Point _startPoint;

        private Point _startOffset;

        public ImageScroll(ScrollViewer scrollViewer, Image mapImage)
        {
            _scroll = scrollViewer;
            _image = mapImage;
            RegisterHandlers();
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Capture pointer and store initial position
            _image.CapturePointer(e.Pointer);
            _startPoint = e.GetCurrentPoint(_image).Position;
            _startOffset = new Point(_scroll.HorizontalOffset, _scroll.VerticalOffset);
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var currentPoint = e.GetCurrentPoint(_image);
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
            _scroll.ChangeView(offsetX, offsetY, null, false);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            // Release the captured pointer
            _image.ReleasePointerCapture(e.Pointer);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // This event is raised when the image has been measured and arranged
            double initialHorizontalOffset = (_image.ActualWidth - _scroll.ActualWidth) / 3;
            double initialVerticalOffset = (_image.ActualHeight - _scroll.ActualHeight) / 2;

            // Set the initial scroll position
            _scroll.ChangeView(initialHorizontalOffset, initialVerticalOffset, null);

            // Unsubscribe from the event, as we only need to do this once
            _image.SizeChanged -= OnSizeChanged;
        }

        /// <summary>
        /// Links all Map instance events to actual FullMap
        /// </summary>
        private void RegisterHandlers()
        {
            _image.SizeChanged += OnSizeChanged;
            _image.PointerPressed += OnPointerPressed;
            _image.PointerMoved += OnPointerMoved;
            _image.PointerReleased += OnPointerReleased;
        }
    }
}