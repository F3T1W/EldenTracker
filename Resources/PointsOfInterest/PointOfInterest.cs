using System;
using System.ComponentModel;

namespace EldenTracker.Resources.PointsOfInterest
{
    public class PointOfInterest
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Uri ImageSource { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public PointOfInterest(double xCoordinate, double yCoordinate, PointOfInterestType type)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            ImageSource = new Uri(GetImagePath(type));
        }

        private string GetImagePath(PointOfInterestType type)
        {
            switch (type)
            {
                case PointOfInterestType.Default:
                    return "ms-appx:///Resources/PointsOfInterest/Images/DefaultPoint.png";
                case PointOfInterestType.Custom:
                    return "ms-appx:///Resources/PointsOfInterest/Images/CustomPoint.png";
                default:
                    return string.Empty;
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}