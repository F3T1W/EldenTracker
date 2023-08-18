using System.Threading;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace EldenTracker.NavigationPages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        private Frame _contentFrame; // Add this field to your MainPage class
        private NavigationView LeftPanelNavigationView;

        public Page1()
        {
            InitializeComponent();
            _contentFrame = Window.Current.Content as Frame;// Create the Frame instance here or assign the reference from wherever you create it dynamically

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateNavigationPanel(_contentFrame);
        }

        private void CreateNavigationPanel(Frame contentFrame)
        {
            LeftPanelNavigationView = new NavigationView
            {
                Name = "LeftPanelNavigationView",
                Style = (Style)Application.Current.Resources["NavigationViewWithoutAnimation"], // Use Application.Current.Resources to access the styles
                PaneDisplayMode = NavigationViewPaneDisplayMode.LeftCompact
            };

            LeftPanelNavigationView.ItemInvoked += LeftPanelNavigationView_ItemInvoked;

            NavigationViewItem Page1NavItem = new NavigationViewItem
            {
                Name = "Page1NavItem",
                Content = "Wiki",
                Icon = new BitmapIcon { UriSource = new Uri("ms-appx:///Assets/wiki.png") }
            };

            NavigationViewItem Page2NavItem = new NavigationViewItem
            {
                Name = "Page2NavItem",
                Content = "Open map",
                Icon = new BitmapIcon { UriSource = new Uri("ms-appx:///Assets/cross.png") }
            };

            Page2NavItem.Tapped += (sender, args) =>
            {
                if (contentFrame.CurrentSourcePageType != typeof(MainPage))
                {
                    // Reset the ContentFrame to its original state
                    contentFrame.Navigate(typeof(MainPage));
                    contentFrame.BackStack.Clear(); // Clear back stack to remove any previous navigation history
                }
            };

            LeftPanelNavigationView.MenuItems.Add(Page1NavItem);
            LeftPanelNavigationView.MenuItems.Add(Page2NavItem);

            // Add the dynamically created NavigationView to the Grid
            MainGrid.Children.Add(LeftPanelNavigationView);
        }

        private void LeftPanelNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // Handle settings invocation if needed
                return;
            }

            NavigationViewItem Page1NavItem = sender.MenuItems[0] as NavigationViewItem;
            NavigationViewItem Page2NavItem = sender.MenuItems[1] as NavigationViewItem;

            if (_contentFrame != null && Page1NavItem != null && Page2NavItem != null)
            {
                if (args.InvokedItemContainer == Page1NavItem && _contentFrame.CurrentSourcePageType != typeof(Page1))
                {
                    // Navigate to Page1 if it's not already the current page
                    _contentFrame.Navigate(typeof(Page1));
                }
                else if (args.InvokedItemContainer == Page2NavItem && _contentFrame.CurrentSourcePageType != typeof(MainPage))
                {
                    // Reset the ContentFrame to its original state
                    _contentFrame.Navigate(typeof(MainPage));
                    _contentFrame.BackStack.Clear(); // Clear back stack to remove any previous navigation history
                }
            }
        }
    }
}
