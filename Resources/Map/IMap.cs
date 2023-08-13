using Windows.UI.Xaml.Input;

public interface IMap
{
    void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e);
    void MapImage_PointerMoved(object sender, PointerRoutedEventArgs e);
    void MapImage_PointerReleased(object sender, PointerRoutedEventArgs e);
    //TODO: Realize switching maps by pressing N key on keyboard
    void MapImageChange_KeyDown(object sender, KeyRoutedEventArgs e);
}