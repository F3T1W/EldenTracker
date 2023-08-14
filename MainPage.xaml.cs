using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner or Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMap Map { get; set; }

        public MainPage()
        {
            InitializeComponent();

            mapImage.SizeChanged += MapImage_SizeChanged;

            CreateComponents();

            Uri combinedImageUri = new Uri("ms-appx:///Resources/Map/Images/FullMap.png");
            BitmapImage bitmapImage = new BitmapImage(combinedImageUri);
            mapImage.Source = bitmapImage;

            mapImage.PointerPressed += Map.MapImage_PointerPressed;
            mapImage.PointerMoved += Map.MapImage_PointerMoved;
            mapImage.PointerReleased += Map.MapImage_PointerReleased;
        }

        private void CreateComponents()
        {
            Map = new Map(scrollViewer, mapImage);
        }

        private void MapImage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // This event is raised when the image has been measured and arranged
            double initialHorizontalOffset = (mapImage.ActualWidth - scrollViewer.ActualWidth) / 3;
            double initialVerticalOffset = (mapImage.ActualHeight - scrollViewer.ActualHeight) / 2;

            // Set the initial scroll position
            scrollViewer.ChangeView(initialHorizontalOffset, initialVerticalOffset, null);

            // Unsubscribe from the event, as we only need to do this once
            mapImage.SizeChanged -= MapImage_SizeChanged;
        }
    }
}
