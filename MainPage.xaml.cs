using Windows.UI.Xaml.Controls;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner of Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private bool IsToggleOn = true;
        private IMap Map { get; set; }

        public MainPage()
        {
            InitializeComponent();
            CreateComponents();

            mapImage.PointerPressed += Map.MapImage_PointerPressed;
            mapImage.PointerMoved += Map.MapImage_PointerMoved;
            mapImage.PointerReleased += Map.MapImage_PointerReleased;

            //Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;


            //var bitmapImage = new BitmapImage
            //{
            //    UriSource = new Uri("C:\\Users\\parti\\source\\repos\\EldenTracker\\bin\\x64\\Debug\\Resources\\Map\\Images\\Underground.png")
            //};
            //bitmapImage.ImageOpened += (s, e) =>
            //{
            //    Here, you can access the Width and Height properties
            //    double imageWidth = bitmapImage.PixelWidth;
            //    double imageHeight = bitmapImage.PixelHeight;

            //    Update the Image control with the loaded BitmapImage
            //    mapImage.Source = bitmapImage;
            //};
        }

        private void CreateComponents()
        {
            Map = new Map(scrollViewer, mapImage);
        }

        //TODO: Realize switching maps by pressing N key on keyboard (XAML too)
        //private async void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        //{
        //    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //    {
        //        if (args.VirtualKey == VirtualKey.N)
        //        {
        //            // Toggle between two image paths
        //            if (IsToggleOn)
        //            {
        //                var bitmapImage = new BitmapImage
        //                {
        //                    UriSource = new Uri("C:\\Users\\parti\\source\\repos\\EldenTracker\\bin\\x64\\Debug\\Resources\\Map\\Images\\Underground.png")
        //                };
        //                bitmapImage.ImageOpened += (s, e) =>
        //                {
        //                    // Here, you can access the Width and Height properties
        //                    double imageWidth = bitmapImage.PixelWidth;
        //                    double imageHeight = bitmapImage.PixelHeight;

        //                    // Update the Image control with the loaded BitmapImage
        //                    mapImage.Source = bitmapImage;
        //                };
        //            }
        //            else
        //            {
        //                var bitmapImage = new BitmapImage();
        //                bitmapImage.UriSource = new Uri("ms-appx:///bin//x64//Debug//Resources//Map//Images//Original.png");
        //                bitmapImage.ImageOpened += (s, e) =>
        //                {
        //                    // Here, you can access the Width and Height properties
        //                    double imageWidth = bitmapImage.PixelWidth;
        //                    double imageHeight = bitmapImage.PixelHeight;

        //                    // Update the Image control with the loaded BitmapImage
        //                    mapImage.Source = bitmapImage;
        //                };
        //            }

        //            // Toggle the state
        //            IsToggleOn = !IsToggleOn;
        //        }
        //        UpdateLayout(); // Update the entire page
        //    });
        //}
    }
}
