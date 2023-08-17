using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace EldenTracker.Resources.PointsOfInterest
{
    public sealed partial class PointOfInterestControl : UserControl
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
            // Register for the LeftTapped event (or MouseButtonUp for desktop)
            Tapped += PointOfInterestControl_Tapped;
            DataContextChanged += UserControl_DataContextChanged;
        }

        private void PointOfInterestControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var poi = DataContext as PointOfInterest;

            if (poi != null && e.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                PointOfInterestClicked?.Invoke(this, poi);
                // You can add more conditions for handling other click events if needed
            }
        }

        private void UserControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            // Update the DataContext of child elements (Bindings) to the new DataContext
            UpdateLayout();
        }
    }
}
