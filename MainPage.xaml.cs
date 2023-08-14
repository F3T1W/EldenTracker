using EldenTracker.Resources.PointsOfInterest;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner or Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PointOfInterest> PointsOfInterest { get; } = new ObservableCollection<PointOfInterest>();
        private IMap Map { get; set; }

        public MainPage()
        {
            InitializeComponent();
            CreateComponents();
            EventHandlerLink();

            PointsOfInterest.Add(new PointOfInterest(2000, 2000));
            PointsOfInterest.Add(new PointOfInterest(2500, 2500));
            PointsOfInterest.Add(new PointOfInterest(3000, 3000));
            PointsOfInterest.Add(new PointOfInterest(3500, 3500));
            PointsOfInterest.Add(new PointOfInterest(4000, 4000));
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
