using EldenTracker.Resources.Map;
using EldenTracker.Resources.MenuButton;
using EldenTracker.Resources.PointsOfInterest;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner or Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PointOfInterest> PointsOfInterest { get; } = new ObservableCollection<PointOfInterest>();
        private Map Map { get; set; }
        private MenuButton MenuButton { get; set; }

        public MainPage()
        {
            InitializeComponent();

            CreateComponents();
            LinkEvents();

            PointsOfInterest.Add(new PointOfInterest(new Point(2000, 2000)));
            PointsOfInterest.Add(new PointOfInterest(new Point(2500, 2500)));
            PointsOfInterest.Add(new PointOfInterest(new Point(3000, 3000)));
            PointsOfInterest.Add(new PointOfInterest(new Point(3500, 3500)));
            PointsOfInterest.Add(new PointOfInterest(new Point(4000, 4000)));
        }

        /// <summary>
        /// Initialize all needed class Instances
        /// </summary>
        private void CreateComponents()
        {
            Map = new Map(ScrollViewer, MapImage);
            MenuButton = new MenuButton(LeftPanelSplitView, ToggleSplitViewButton);
        }

        private void LinkEvents()
        {
            Map.MapEventHandlerLink(MapImage);

            ToggleSplitViewButton.Click += MenuButton.ToggleSplitViewButton_Click;

            ToggleSplitViewButton.RightTapped += ScrollViewer_RightTapped;
        }


        /// <summary>
        /// Creates custom PoI (PointOfInterest) on the place you RMB'ed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollViewer_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Point position = e.GetPosition(MapImage);

            double xCoordinate = position.X - 16;
            double yCoordinate = position.Y - 16;

            PointsOfInterest.Add(new PointOfInterest(new Point(xCoordinate, yCoordinate), PointOfInterestType.Custom));
        }
    }
}
