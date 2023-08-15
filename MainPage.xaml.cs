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

            PointsOfInterest.Add(new PointOfInterest(2000, 2000, PointOfInterestType.Default));
            PointsOfInterest.Add(new PointOfInterest(2500, 2500, PointOfInterestType.Default));
            PointsOfInterest.Add(new PointOfInterest(3000, 3000, PointOfInterestType.Default));
            PointsOfInterest.Add(new PointOfInterest(3500, 3500, PointOfInterestType.Default));
            PointsOfInterest.Add(new PointOfInterest(4000, 4000, PointOfInterestType.Default));
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

        private void ScrollViewer_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            // Get the position of the right-click event relative to the ScrollViewer
            Windows.Foundation.Point position = e.GetPosition(MapImage);


            // Convert the position to the actual coordinates on the map
            double xCoordinate = position.X - 16;
            double yCoordinate = position.Y - 16;

            // Create a new PointOfInterest instance with the calculated coordinates
            PointsOfInterest.Add(new PointOfInterest(xCoordinate, yCoordinate, PointOfInterestType.Custom));
        }
    }
}
