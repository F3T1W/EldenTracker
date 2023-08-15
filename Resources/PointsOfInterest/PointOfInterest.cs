using System;
using System.ComponentModel;

namespace EldenTracker.Resources.PointsOfInterest
{
    public class PointOfInterest
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string imagePath = "ms-appx:///Resources/PointsOfInterest/Images/SoG.png";
        public Uri ImageSource { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public PointOfInterest(double xCoordinate, double yCoordinate)
        {
            ImageSource = new Uri(imagePath);
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}