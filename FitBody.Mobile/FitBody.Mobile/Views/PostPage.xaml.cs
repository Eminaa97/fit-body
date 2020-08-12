using FitBody.Common.Contracts;
using FitBody.Mobile.Models;
using FitBody.Mobile.ViewModels;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        private readonly PostModel _postDto;

        private ApiService _postService = new ApiService("posts");
        private ApiService _userService = new ApiService("users");
        private ApiService _commentService = new ApiService("comments");

        public PostPage(PostModel postDto)
        {
            InitializeComponent();

            BindingContext = _postDto = postDto;
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var likes = await _postService.Get<IList<PostDto>>(null, "users/likes");
            var saved = await _postService.Get<IList<PostDto>>(null, "users/saved");
            if (likes.Any(x => x.Id == _postDto.Id))
                likeButton.Text = "Unlike";

            if (saved.Any(x => x.Id == _postDto.Id))
                saveButton.Text = "Unsave";
        }

        private async void likeButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var liked = await _postService.Post<bool>(null, $"like/{_postDto.Id}");

                likeButton.Text = liked ? "Unlike" : "Like";
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
                var saved = await _postService.Post<bool>(null, $"save/{_postDto.Id}");

                saveButton.Text = saved ? "Unsave" : "Save";
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
                    PostId = _postDto.Id,
                    Content = comment
                });

                if (apiResponse != null)
                {
                    _postDto.Comments.Add(apiResponse);
                }
                Comment.Text = "";
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void openProfileButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var user = await _userService.GetById<UserDto>(_postDto.UserId);
                await Navigation.PushModalAsync(new NavigationPage(new UserPage(user)));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            
        }

    }
}