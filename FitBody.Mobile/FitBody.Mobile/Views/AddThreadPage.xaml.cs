using FitBody.Common.Contracts;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddThreadPage : ContentPage
    {
        private ApiService _threadService = new ApiService("threads");

        public ThreadInsertModel Thread { get; set; }

        public AddThreadPage()
        {
            InitializeComponent();
            Thread = new ThreadInsertModel();
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                Thread.Title = Title.Text;
                Thread.Content = Content.Text;

                if (string.IsNullOrEmpty(Thread.Title) || string.IsNullOrWhiteSpace(Thread.Title)
                    || string.IsNullOrEmpty(Thread.Content) || string.IsNullOrWhiteSpace(Thread.Content))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Check all fields", "OK");
                    return;
                }
                await _threadService.Post<ThreadDto>(Thread);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}