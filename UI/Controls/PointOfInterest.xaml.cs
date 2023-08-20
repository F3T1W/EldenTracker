using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Devices.Input;

namespace EldenTracker.UI.Controls
{
    internal sealed partial class PointOfInterest : UserControl
    {
        public event EventHandler<Model.PointOfInterest> Clicked;

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(string), typeof(PointOfInterest), new PropertyMetadata(null));

        public static readonly DependencyProperty XCoordinateProperty =
            DependencyProperty.Register("XCoordinate", typeof(double), typeof(Model.PointOfInterest), new PropertyMetadata(0.0));

        public static readonly DependencyProperty YCoordinateProperty =
            DependencyProperty.Register("YCoordinate", typeof(double), typeof(Model.PointOfInterest), new PropertyMetadata(0.0));

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

        public PointOfInterest()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            var point = DataContext as Model.PointOfInterest;
            
            if (point != null && e.PointerDeviceType == PointerDeviceType.Mouse)
            {
                Clicked?.Invoke(this, point);
            }
        }
    }
}
