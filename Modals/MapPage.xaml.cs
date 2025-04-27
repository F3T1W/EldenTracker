using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Input;
using EldenTracker.Model;
using EldenTracker.Modals.Popups;

namespace EldenTracker.Modals;

internal sealed partial class MapPage
{
    public ObservableCollection<PointOfInterest> PointsOfInterest { get; } =
    [
        new(new Point(2000, 2000)),
        new(new Point(2500, 2500)),
        new(new Point(3000, 3000)),
        new(new Point(3500, 3500)),
        new(new Point(4000, 4000))
    ];

    public MapPage() => InitializeComponent();

    private void OnRightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        Point position = e.GetPosition(MapImage);

        double xCoordinate = position.X - 16;
        double yCoordinate = position.Y - 16;

        PointsOfInterest.Add(new PointOfInterest(new Point(xCoordinate, yCoordinate), PointOfInterest.Type.Custom));
    }

    private void OnPointOfInterestControlClicked(object sender, PointOfInterest e) =>
        new PointDialog(e.ImageSource).ShowAsync();
}
