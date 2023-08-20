using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using EldenTracker.UI.Pages;
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
            var tag = args.InvokedItem as string;
            
            Type requestedPage;
            if (tag == TagOf(WikiItem))
            {
                requestedPage = typeof(WikiPage);
            }
            else if (tag == TagOf(MapItem))
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

        private string TagOf(NavigationViewItem item) => item.Content as string;
    }
}
