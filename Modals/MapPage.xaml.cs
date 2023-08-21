using System;
using System.Collections.ObjectModel;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using EldenTracker.Modals.Utils;
using EldenTracker.Model;
using EldenTracker.Modals.Popups;

namespace EldenTracker.Modals
{
    internal sealed partial class MapPage : Page
    {
        private readonly ImageScroll _map;

        public ObservableCollection<PointOfInterest> PointsOfInterest { get; } = new ObservableCollection<PointOfInterest>()
        {
            new PointOfInterest(new Point(2000, 2000)),
            new PointOfInterest(new Point(2500, 2500)),
            new PointOfInterest(new Point(3000, 3000)),
            new PointOfInterest(new Point(3500, 3500)),
            new PointOfInterest(new Point(4000, 4000)),
        };

        public PointOfInterest SelectedPOI { get; set; } // Create the SelectedPOI property

        public MapPage()
        {
            InitializeComponent();
            _map = new ImageScroll(ScrollViewer, MapImage);
        }

        /// <summary>
        /// Creates custom PoI (PointOfInterest) on the place you RMB'ed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var position = e.GetPosition(MapImage);

            var xCoordinate = position.X - 16;
            var yCoordinate = position.Y - 16;

            PointsOfInterest.Add(new PointOfInterest(new Point(xCoordinate, yCoordinate), PointOfInterest.Type.Custom));
        }

        private async void OnPointOfInterestControlClicked(object sender, PointOfInterest e)
        {
            await new PointDialog(e.ImageSource).ShowAsync();
        }
    }
}
