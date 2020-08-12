using FitBody.Common.Contracts;
using FitBody.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        private UsersViewModel _model;
        
        public UsersPage()
        {
            InitializeComponent();

            BindingContext = _model = new UsersViewModel();
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                await _model.Init();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void UsersItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var user = e.SelectedItem as UserDto;
                //await Navigation.PushAsync(new UserPage(user));
                await Navigation.PushModalAsync(new NavigationPage(new UserPage(user)));
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
                var username = UserName.Text;
                await _model.Filter(username);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}