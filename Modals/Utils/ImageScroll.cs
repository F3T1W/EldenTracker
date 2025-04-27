using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace EldenTracker.Modals.Utils;

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
        _image.CapturePointer(e.Pointer);
        _startPoint = e.GetCurrentPoint(_image).Position;
        _startOffset = new Point(_scroll.HorizontalOffset, _scroll.VerticalOffset);
    }

    private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
    {
        PointerPoint currentPoint = e.GetCurrentPoint(_image);
            
        if (currentPoint.Properties.IsLeftButtonPressed == false)
        {
            return;
        }
            
        Point currentPosition = currentPoint.Position;
            
        double offsetX = _startOffset.X + (_startPoint.X - currentPosition.X);
        double offsetY = _startOffset.Y + (_startPoint.Y - currentPosition.Y);

        if (offsetX < 0 || offsetY < 0)
        {
            return;
        }

        _scroll.ChangeView(offsetX, offsetY, null, false);
    }

    private void OnPointerReleased(object sender, PointerRoutedEventArgs e) => 
        _image.ReleasePointerCapture(e.Pointer);

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        double initialHorizontalOffset = (_image.ActualWidth - _scroll.ActualWidth) / 3;
        double initialVerticalOffset = (_image.ActualHeight - _scroll.ActualHeight) / 2;

        _scroll.ChangeView(initialHorizontalOffset, initialVerticalOffset, null);

        _image.SizeChanged -= OnSizeChanged;
    }

    private void RegisterHandlers()
    {
        _image.SizeChanged += OnSizeChanged;
        _image.PointerPressed += OnPointerPressed;
        _image.PointerMoved += OnPointerMoved;
        _image.PointerReleased += OnPointerReleased;
    }
}
