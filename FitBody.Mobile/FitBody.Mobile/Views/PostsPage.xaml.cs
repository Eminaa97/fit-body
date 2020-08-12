using FitBody.Mobile.Models;
using FitBody.Mobile.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsPage : ContentPage
    {
        private readonly PostsViewModel _model = null;

        public PostsPage()
        {
            InitializeComponent();

            BindingContext = _model = new PostsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ApiService.Permission == 0)
            {
                btnAdd.IsVisible = false;
            }
            try
            {
                if (!SignalR.Connected)
                {
                    await SignalR.HubConnection.StartAsync();
                    SignalR.Connected = true;
                }

                SignalR.HubConnection.On<string, string>("ReceiveNotification", async (userfollowers, creator) =>
                {
                    await _model.Init();
                });
                await _model.Init();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void PostItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var post = e.SelectedItem as PostModel;
                //await Navigation.PushAsync(new PostPage(post));
                await Navigation.PushModalAsync(new NavigationPage(new PostPage(post)));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var title = Title.Text;
                await _model.Filter(title);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var addPostPage = new NavigationPage(new AddPostPage());
                await Navigation.PushModalAsync(addPostPage);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

    }
}