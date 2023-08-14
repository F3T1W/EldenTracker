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
            Map = new Map(ScrollViewer, MapImage);
        }

        private void EventHandlerLink()
        {
            MapEventHandlerLink();

            ToggleGridButton.Click += ToggleGridButton_Click;
        }

        private void MapEventHandlerLink()
        {
            MapImage.SizeChanged += Map.MapImage_SizeChanged;
            MapImage.PointerPressed += Map.MapImage_PointerPressed;
            MapImage.PointerMoved += Map.MapImage_PointerMoved;
            MapImage.PointerReleased += Map.MapImage_PointerReleased;
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
