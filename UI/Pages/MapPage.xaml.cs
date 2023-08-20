using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using EldenTracker.Model;
using EldenTracker.UI.Popups;
using System.Numerics;

namespace EldenTracker.UI.Pages
{
    internal sealed partial class MapPage : Page
    {
        public ObservableCollection<PointOfInterest> PointsOfInterest { get; } = new ObservableCollection<PointOfInterest>()
        {
            new PointOfInterest(new Vector2(2000, 2000)),
            new PointOfInterest(new Vector2(2500, 2500)),
            new PointOfInterest(new Vector2(3000, 3000)),
            new PointOfInterest(new Vector2(3500, 3500)),
            new PointOfInterest(new Vector2(4000, 4000)),
        };

        public MapPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates custom PoI (PointOfInterest) on the place you RMB'ed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var clickPosition = e.GetPosition(Map).ToVector2();
            var coordinates = clickPosition - new Vector2(16, 16);
            PointsOfInterest.Add(new PointOfInterest(coordinates, PointOfInterest.Type.Custom));
        }

        private async void OnPointOfInterestControlClicked(object sender, PointOfInterest e)
        {
            await new PointDialog(e.ImageSource).ShowAsync();
        }
    }
}
