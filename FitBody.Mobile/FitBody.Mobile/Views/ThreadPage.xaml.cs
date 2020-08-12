using FitBody.Common.Contracts;
using FitBody.Mobile.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThreadPage : ContentPage
    {
        private ApiService _threadService = new ApiService("threads");
        private ApiService _userService = new ApiService("users");
        private ApiService _commentService = new ApiService("comments");
        private readonly ThreadModel _threadDto;

        public ThreadPage(ThreadModel threadDto)
        {
            InitializeComponent();
            BindingContext = _threadDto = threadDto;

        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void openProfileButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = await _userService.GetById<UserDto>(_threadDto.UserId);
                await Navigation.PushModalAsync(new NavigationPage(new UserPage(user)));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void commentButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                var comment = Comment.Text;

                if (string.IsNullOrEmpty(comment) || string.IsNullOrWhiteSpace(comment))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please insert a comment first", "OK");
                    return;
                }

                var apiResponse = await _commentService.Post<CommentDto>(new CommentInsertModel
                {
                    ThreadId=_threadDto.Id,
                    Content = comment
                });

                if (apiResponse != null)
                {
                    _threadDto.Comments.Add(apiResponse);
                }
                Comment.Text = "";
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}