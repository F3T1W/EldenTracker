using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using EldenTracker.Modals;
using System;

namespace EldenTracker
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ContentFrame.Navigate(typeof(MapPage));
        }

        private void OnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            Type requestedPage;
            var content = args.InvokedItem;

            if (content.Equals(WikiItem.Content))
            {
                requestedPage = typeof(WikiPage);
            }
            else if (content.Equals(MapItem.Content))
            {
                requestedPage = typeof(MapPage);
            } 
            else
            {
                throw new InvalidOperationException("Unknown navigation item");
            }
            var options = new FrameNavigationOptions()
            {
                TransitionInfoOverride = args.RecommendedNavigationTransitionInfo,
                IsNavigationStackEnabled = false
            };
            ContentFrame.NavigateToType(requestedPage, null, options);
        }
    }
}
