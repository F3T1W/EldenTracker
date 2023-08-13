using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner of Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMap _map;
        private ScrollViewer _scrollViewer;
        private Image _mapImage;

        private Point startPoint;
        private Point startOffset;
        private Point zoomCenter;

        public MainPage()
        {
            InitializeComponent();

            _scrollViewer = scrollViewer; // Replace with your ScrollViewer's x:Name
            _mapImage = mapImage;

            _map = new Map(scrollViewer, mapImage);

            mapImage.PointerPressed += MapImage_PointerPressed;
            mapImage.PointerMoved += MapImage_PointerMoved;
            mapImage.PointerReleased += MapImage_PointerReleased;
        }

        private void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Capture pointer and store initial position
            mapImage.CapturePointer(e.Pointer);
            startPoint = e.GetCurrentPoint(mapImage).Position;
            startOffset = new Point(scrollViewer.HorizontalOffset, scrollViewer.VerticalOffset);
        }

        private void MapImage_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(mapImage).Properties.IsLeftButtonPressed)
            {
                // Calculate new offset based on pointer movement
                Point currentPosition = e.GetCurrentPoint(mapImage).Position;
                double offsetX = startOffset.X + (startPoint.X - currentPosition.X);
                double offsetY = startOffset.Y + (startPoint.Y - currentPosition.Y);

                // Update the ScrollViewer's offset
                scrollViewer.ChangeView(offsetX, offsetY, null, false);
            }
        }

        private void MapImage_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            // Release the captured pointer
            mapImage.ReleasePointerCapture(e.Pointer);
        }

        private async void MapImage_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            // Disable ScrollViewer's scrolling temporarily
            scrollViewer.HorizontalScrollMode = ScrollMode.Disabled;
            scrollViewer.VerticalScrollMode = ScrollMode.Disabled;

            try
            {
                int wheelDelta = e.GetCurrentPoint(mapImage).Properties.MouseWheelDelta;
                double zoomFactor = 1.1;
                double currentScale = (mapImage.RenderTransform as ScaleTransform).ScaleX;
                double newScale = wheelDelta > 0 ? currentScale * zoomFactor : currentScale / zoomFactor;

                // Limit the zoom factor (optional)
                double minScale = 0.5;
                double maxScale = 3.0;
                newScale = Math.Max(minScale, Math.Min(maxScale, newScale));

                // Apply the new scale to the ScaleTransform
                (mapImage.RenderTransform as ScaleTransform).ScaleX = newScale;
                (mapImage.RenderTransform as ScaleTransform).ScaleY = newScale;

                Point relativeZoomCenter = e.GetCurrentPoint(mapImage).Position;
                double offsetX = relativeZoomCenter.X * (1 - newScale) + zoomCenter.X;
                double offsetY = relativeZoomCenter.Y * (1 - newScale) + zoomCenter.Y;
                scrollViewer.ChangeView(offsetX, offsetY, null, false);
            }
            finally
            {
                // Re-enable ScrollViewer's scrolling
                await Task.Delay(10); // Allow a small delay for the layout to update
                scrollViewer.HorizontalScrollMode = ScrollMode.Auto;
                scrollViewer.VerticalScrollMode = ScrollMode.Auto;
            }
        }
    }
}
