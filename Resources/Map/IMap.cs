using Windows.UI.Xaml.Input;

public interface IMap
{
    void MapImage_PointerPressed(object sender, PointerRoutedEventArgs e);
    void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e);
}