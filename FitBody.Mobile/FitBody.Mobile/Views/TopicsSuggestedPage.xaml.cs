using FitBody.Common.Contracts;
using FitBody.Mobile.ViewModels;
using Syncfusion.XForms.Buttons;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicsSuggestedPage : ContentPage
    {
        private readonly TopicsSuggestedViewModel _model = null;
        private ApiService _topicsService = new ApiService("TopicsSuggested");
        private object _clickedObject = null;

        public TopicsSuggestedPage()
        {
            InitializeComponent();
            BindingContext = _model = new TopicsSuggestedViewModel();

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
        private async void TopicItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var topics = e.SelectedItem as TopicSuggestedDto;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void cancelButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                SfButton button = sender as SfButton;
                StackLayout listViewItem = button.Parent as StackLayout;
                var topicSuggestedDto = listViewItem.Parent.BindingContext as TopicSuggestedDto;
                await _topicsService.Delete<dynamic>(topicSuggestedDto.Id);

                await _model.Init();

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        
        private async void addButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                SfButton button = sender as SfButton;
                StackLayout listViewItem = button.Parent as StackLayout;
                _clickedObject = listViewItem.Parent.BindingContext as TopicSuggestedDto;

                var addPostPage = new NavigationPage(new AddPostPage());
                addPostPage.Disappearing += AddPostPage_Disappearing;

                await Navigation.PushModalAsync(addPostPage);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void AddPostPage_Disappearing(object sender, EventArgs e)
        {
            var topicSuggestedDto = _clickedObject as TopicSuggestedDto;
            await _topicsService.Delete<dynamic>(topicSuggestedDto.Id);

            await _model.Init();
        }
    }
}