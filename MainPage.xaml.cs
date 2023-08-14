using Windows.UI.Xaml.Controls;

namespace EldenTracker
{
    /// <summary>
    /// Empty page, could be used in inner or Frame switch.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IMap Map { get; set; }

        public MainPage()
        {
            InitializeComponent();
            CreateComponents();

            mapImage.PointerPressed += Map.MapImage_PointerPressed;
            mapImage.PointerMoved += Map.MapImage_PointerMoved;
            mapImage.PointerReleased += Map.MapImage_PointerReleased;
        }

        private void CreateComponents()
        {
            Map = new Map(scrollViewer, mapImage);
        }
    }
}
