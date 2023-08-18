using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using EldenTracker.Model;

namespace EldenTracker.Modals
{
    internal sealed partial class PointOfInterestControl : UserControl
    {
        public event EventHandler<PointOfInterest> PointOfInterestClicked;

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(PointOfInterestControl), new PropertyMetadata(null));

        public static readonly DependencyProperty XCoordinateProperty =
            DependencyProperty.Register("XCoordinate", typeof(double), typeof(PointOfInterest), new PropertyMetadata(0.0));

        public static readonly DependencyProperty YCoordinateProperty =
            DependencyProperty.Register("YCoordinate", typeof(double), typeof(PointOfInterest), new PropertyMetadata(0.0));

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public double XCoordinate
        {
            get { return (double)GetValue(XCoordinateProperty); }
            set { SetValue(XCoordinateProperty, value); }
        }

        public double YCoordinate
        {
            get { return (double)GetValue(YCoordinateProperty); }
            set { SetValue(YCoordinateProperty, value); }
        }

        public PointOfInterestControl()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var poi = DataContext as PointOfInterest;

            if (poi != null && e.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                PointOfInterestClicked?.Invoke(this, poi);
            }
        }
    }
}
