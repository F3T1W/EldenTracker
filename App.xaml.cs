using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace EldenTracker;

public sealed partial class App
{
    public App()
    {
        InitializeComponent();
        Suspending += OnSuspending;
    }
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        if (Window.Current.Content is not Frame rootFrame)
        {
            rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;

            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Загрузить состояние из ранее приостановленного приложения
            }

            Window.Current.Content = rootFrame;
        }

        if (e.PrelaunchActivated)
        {
            return;
        }

        if (rootFrame.Content == null)
        {
            rootFrame.Navigate(typeof(MainPage), e.Arguments);
        }
        
        Window.Current.Activate();
    }

    private static void OnNavigationFailed(object sender, NavigationFailedEventArgs e) =>
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);

    private static void OnSuspending(object sender, SuspendingEventArgs e)
    {
        SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
            
        //TODO: Сохранить состояние приложения и остановить все фоновые операции
        deferral.Complete();
    }
}
