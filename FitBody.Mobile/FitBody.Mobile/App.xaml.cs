using FitBody.Mobile.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace FitBody.Mobile
{
    public static class SignalR
    {
        public static HubConnection HubConnection;
        public static bool Connected;
    }

    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("Mjk3MjczQDMxMzgyZTMyMmUzMFYxeFJZM3dJbFVHWW1jcWJqdWxIck9DMTZ5ZHZxN293L1FZcy9HU3FTMWc9");

            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
