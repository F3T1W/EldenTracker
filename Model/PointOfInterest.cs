using System;
using System.ComponentModel;
using Windows.Foundation;

namespace EldenTracker.Model;

internal sealed class PointOfInterest(Point point, PointOfInterest.Type type = PointOfInterest.Type.Default)
    : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public Uri ImageSource { get; } = GetImageUri(type);

    public double XCoordinate { get; } = point.X;

    public double YCoordinate { get; } = point.Y;

    public enum Type : byte
    {
        Default,
        Custom
    }

    private static Uri GetImageUri(Type type)
    {
        string name = type == Type.Default
            ? nameof(Type.Default)
            : nameof(Type.Custom);
        return new Uri(@$"ms-appx:///Assets/{name}Point.png");
    }

    public void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
