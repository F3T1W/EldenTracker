using Windows.UI.Xaml.Controls;

namespace EldenTracker.Modals
{
    public sealed partial class WikiPage : Page
    {
        public WikiPage()
        {
            InitializeComponent();
        }

// оставил чтобы не потерять логику анимации
#if false

        private void CreateNavigationPanel(Frame contentFrame)
        {
            LeftPanelNavigationView = new NavigationView
            {
                Name = "LeftPanelNavigationView",
                Style = (Style)Application.Current.Resources["NavigationViewWithoutAnimation"], // Use Application.Current.Resources to access the styles
                PaneDisplayMode = NavigationViewPaneDisplayMode.LeftCompact
            };
    }
#endif
    }
}
