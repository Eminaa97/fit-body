using FitBody.Mobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {

        private ApiService _userService = new ApiService("users");
        private EditUserViewModel _model;
        public EditUserPage()
        {
            InitializeComponent();
            BindingContext = _model = new EditUserViewModel();
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

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await _model.Save();
                await Application.Current.MainPage.DisplayAlert("Info", "User successfully updated", "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}