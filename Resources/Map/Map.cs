using Windows.Foundation;
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

        MapImage.PointerPressed += MapImage_PointerPressed;
    }

    public void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        StartOffset = new Point(ScrollViewer.HorizontalOffset, ScrollViewer.VerticalOffset);

        MapImage.CapturePointer(e.Pointer);
    }

    public void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        var newOffset = new Point(StartOffset.X - e.Cumulative.Translation.X, StartOffset.Y - e.Cumulative.Translation.Y);
        ScrollViewer.ChangeView(newOffset.X, newOffset.Y, null, false);
    }
}