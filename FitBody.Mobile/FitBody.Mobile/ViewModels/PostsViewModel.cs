using FitBody.Common.Contracts;
using FitBody.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FitBody.Mobile.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {
        private readonly ApiService _postsService = new ApiService("posts");
        private readonly ApiService _commentsService = new ApiService("comments");
        private readonly bool _blog = false;

        public ObservableCollection<PostDto> PostsList { get; set; } = new ObservableCollection<PostDto>();
        public ICommand InitCommand { get; set; }

        public PostsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            _blog = false;
        }

        public PostsViewModel(bool blog = false)
        {
            InitCommand = new Command(async () => await Init());
            _blog = blog;
        }

        public async Task Init()
        {
            try
            {
                PostsList.Clear();

                IList<PostModel> posts = null;

                if (!_blog)
                {
                    posts = await _postsService.Get<IList<PostModel>>();
                }
                else
                {
                    posts = await _postsService.Get<IList<PostModel>>(null, "followed");
                }

                foreach (var item in posts)
                {
                    //item.Comments = await _commentsService.Get<IList<CommentDto>>(null, $"posts/{item.Id}");
                    var data = await _commentsService.Get<IList<CommentDto>>(null, $"posts/{item.Id}");
                    item.Comments = new ObservableCollection<CommentDto>(data);
                    PostsList.Add(item);
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task Filter(string Title)
        {
            try
            {
                var postSearch = await _postsService.Get<IList<PostModel>>(new PostSearchRequest
                {
                    Title = Title
                }, "search");
                PostsList.Clear();

                foreach (var item in postSearch)
                {
                    PostsList.Add(item);
                    item.Comments = new ObservableCollection<CommentDto>();

                    var comments = await _commentsService.Get<IList<CommentDto>>(null, $"posts/{item.Id}");
                    comments.ForEach(x =>
                    {
                        item.Comments.Add(x);
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
