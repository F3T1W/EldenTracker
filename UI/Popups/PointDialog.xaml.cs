using System;
using Windows.UI.Xaml.Controls;

namespace EldenTracker.UI.Popups
{
    internal sealed partial class PointDialog : ContentDialog
    {
        public PointDialog(Uri iconSource)
        {
            InitializeComponent();
            PointIcon.UriSource = iconSource;
        }

        private void OnOKClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }

        private void OnCancelClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Hide();
        }
    }
}
