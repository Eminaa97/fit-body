using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private readonly UserDto _user;
        private ApiService _userService = new ApiService("users");
        private ApiService _topicsService = new ApiService("TopicsSuggested");

        public UserPage(UserDto user)
        {
            InitializeComponent();
            BindingContext = _user = user;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_user.Id != ApiService.LoggedInUserId)
            {
                logoutButton.IsVisible = false;
            }

            var followers = await _userService.Get<IList<UserFollowDto>>(null, $"followers/{_user.Id}");
            
            if (followers.Any(x => x.Id == ApiService.LoggedInUserId))
                followButton.Text = "Unfollow";
        }
        private async void followButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var follow = await _userService.Post<bool>(null, $"follow/{_user.Id}");

                followButton.Text = follow ? "Unfollow" : "Follow";
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void topicButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var topic = Topic.Text;

                if (string.IsNullOrEmpty(topic) || string.IsNullOrWhiteSpace(topic))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please suggest a topic first", "OK");
                    return;
                }

                var apiResponse = await _topicsService.Post<TopicSuggestedDto>(new TopicSuggestedInsertModel
                {
                    Topic = topic,
                    UserId=_user.Id,
                    DateCreated=DateTime.UtcNow
                });

                Topic.Text = "";
                await Application.Current.MainPage.DisplayAlert("Successfully added", "Successfully added topic", "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void logoutButton_Clicked(object sender, EventArgs e)
        {
            ApiService.Token = null;
            ApiService.LoggedInUserId = -1;
            ApiService.Permission = -1;

            await Navigation.PushAsync(new NavigationPage(new LoginPage()));
        }

    }
}