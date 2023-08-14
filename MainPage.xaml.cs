using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            CreateComponents();
            EventHandlerLink();
        }

        private void CreateComponents()
        {
            Map = new Map(scrollViewer, mapImage);
        }

        private void EventHandlerLink()
        {
            mapImage.SizeChanged += Map.MapImage_SizeChanged;
            mapImage.PointerPressed += Map.MapImage_PointerPressed;
            mapImage.PointerMoved += Map.MapImage_PointerMoved;
            mapImage.PointerReleased += Map.MapImage_PointerReleased;
        }

        private void ToggleGridButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftPanelGrid.Visibility == Visibility.Collapsed)
            {
                LeftPanelGrid.Visibility = Visibility.Visible;
                ButtonGrid.Margin = new Thickness(500, 40, 0, 0);
                ToggleGridButton.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                LeftPanelGrid.Visibility = Visibility.Collapsed;
                ButtonGrid.Margin = new Thickness(0, 40, 0, 0);
                ToggleGridButton.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }
    }
}
