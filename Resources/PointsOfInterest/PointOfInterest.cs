using System;

namespace EldenTracker.Resources.PointsOfInterest
{
    public class PointOfInterest
    {
        public Uri ImageSource { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public PointOfInterest(Uri imageSource, double xCoordinate, double yCoordinate)
        {
            ImageSource = imageSource;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
    }
}