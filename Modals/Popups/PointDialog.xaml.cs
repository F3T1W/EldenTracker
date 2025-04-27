using System;
using Windows.UI.Xaml.Controls;

namespace EldenTracker.Modals.Popups;

internal sealed partial class PointDialog
{
    public PointDialog(Uri imageSource)
    {
        InitializeComponent();
        PointIcon.UriSource = imageSource;
    }

    private void OnOKClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args) => Hide();

    private void OnCancelClicked(ContentDialog sender, ContentDialogButtonClickEventArgs args) => Hide();
}
