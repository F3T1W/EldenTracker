using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

public interface IMap
{
    void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e);
    void MapImage_PointerMoved(object sender, PointerRoutedEventArgs e);
    void MapImage_PointerReleased(object sender, PointerRoutedEventArgs e);
    void MapImage_SizeChanged(object sender, SizeChangedEventArgs e);
}