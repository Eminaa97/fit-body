using FitBody.Common.Contracts;
using FitBody.Mobile.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitBody.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPostPage : ContentPage
    {
        private ApiService _postService = new ApiService("posts");
        private AddPostViewModel _model;

        public PostInsertModel Post { get; set; }

        public AddPostPage()
        {
            InitializeComponent();
            Post = new PostInsertModel();

            BindingContext = _model = new AddPostViewModel();
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

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                Post.Title = Title.Text;
                Post.Content = Content.Text;
                Post.Tags = Tags.Text.Split(',');
                Post.SubcategoryId = _model.SelectedSubcategory.Id;

                if (string.IsNullOrEmpty(Post.Title) || string.IsNullOrWhiteSpace(Post.Title) 
                    || string.IsNullOrEmpty(Post.Content) || string.IsNullOrWhiteSpace(Post.Content) 
                    || !Post.Tags.Any() || Post.SubcategoryId == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Check all fields", "OK");
                    return;
                }
                await _postService.Post<PostDto>(Post);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            _model.FilterSubcategories();
        }
    }
}