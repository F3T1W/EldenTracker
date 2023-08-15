using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EldenTracker.Resources.MenuButton
{
    public class MenuButton
    {
        private SplitView SplitView { get; set; }
        private Button Button { get; set; }
        public MenuButton(SplitView splitView, Button toggle) {
            SplitView = splitView;
            Button = toggle;
        }
        /// <summary>
        /// Show/hide left-side panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToggleSplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (SplitView.Width == 500)
            {
                SplitView.Width = 0;
                SplitView.IsPaneOpen = false;
                Button.Margin = new Thickness(0, 40, 0, 0);
            }
            else
            {
                SplitView.Width = 500;
                SplitView.IsPaneOpen = true;
                Button.Margin = new Thickness(500, 40, 0, 0);
            }
        }
    }
}
