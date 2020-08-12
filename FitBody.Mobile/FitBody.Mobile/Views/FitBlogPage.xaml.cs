using FitBody.Mobile.Models;
using FitBody.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FitBlogPage : ContentPage
    {
        private readonly PostsViewModel _model = null;

        public FitBlogPage()
        {
            InitializeComponent();
            BindingContext = _model = new PostsViewModel(true);

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

                PostDetailViewModel model = new PostDetailViewModel(post);

                await Navigation.PushModalAsync(new NavigationPage(new PostPage(post)));
                //await Navigation.PushAsync(new PostPage(post));

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}