using FitBody.Mobile.Models;
using FitBody.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendedPostsPage : ContentPage
    {
        private readonly RecommendedPostsViewModel _model = null;

        public RecommendedPostsPage()
        {
            InitializeComponent();

            BindingContext = _model = new RecommendedPostsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
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
    }
}