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
    public partial class FitForumPage : ContentPage
    {
        private readonly FitForumViewModel _model = null;

        public FitForumPage()
        {
            InitializeComponent();
            BindingContext = _model = new FitForumViewModel();
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
        private async void ThreadItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var thread = e.SelectedItem as ThreadModel;
                await Navigation.PushModalAsync(new NavigationPage(new ThreadPage(thread)));
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
                var addThreadPage = new NavigationPage(new AddThreadPage());
                await Navigation.PushModalAsync(addThreadPage);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}