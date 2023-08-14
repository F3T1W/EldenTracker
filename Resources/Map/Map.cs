using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

public class Map : IMap
{
    private Point StartPoint { get; set; }
    private Point StartOffset { get; set; }
    public ScrollViewer ScrollViewer { private get; set; }
    public Image MapImage { private get; set; }

    public Map(ScrollViewer scrollViewer, Image mapImage)
    {
        ScrollViewer = scrollViewer;
        MapImage = mapImage;
    }

    public void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        // Capture pointer and store initial position
        MapImage.CapturePointer(e.Pointer);
        StartPoint = e.GetCurrentPoint(MapImage).Position;
        StartOffset = new Point(ScrollViewer.HorizontalOffset, ScrollViewer.VerticalOffset);
    }

    public void MapImage_PointerMoved(object sender, PointerRoutedEventArgs e)
    {
        if (e.GetCurrentPoint(MapImage).Properties.IsLeftButtonPressed)
        {
            // Calculate new offset based on pointer movement
            Point currentPosition = e.GetCurrentPoint(MapImage).Position;
            double offsetX = StartOffset.X + (StartPoint.X - currentPosition.X);
            double offsetY = StartOffset.Y + (StartPoint.Y - currentPosition.Y);

            // Update the ScrollViewer's offset
            ScrollViewer.ChangeView(offsetX, offsetY, null, false);
        }
    }

    public void MapImage_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        // Release the captured pointer
        MapImage.ReleasePointerCapture(e.Pointer);
    }

    public void MapImage_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        // This event is raised when the image has been measured and arranged
        double initialHorizontalOffset = (MapImage.ActualWidth - ScrollViewer.ActualWidth) / 3;
        double initialVerticalOffset = (MapImage.ActualHeight - ScrollViewer.ActualHeight) / 2;

        // Set the initial scroll position
        ScrollViewer.ChangeView(initialHorizontalOffset, initialVerticalOffset, null);

        // Unsubscribe from the event, as we only need to do this once
        MapImage.SizeChanged -= MapImage_SizeChanged;
    }
}