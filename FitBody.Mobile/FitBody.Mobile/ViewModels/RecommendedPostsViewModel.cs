using FitBody.Common.Contracts;
using FitBody.Mobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class RecommendedPostsViewModel
    {
        private readonly ApiService _postsService = new ApiService("posts");
        private readonly ApiService _commentsService = new ApiService("comments");

        public ObservableCollection<PostDto> PostsList { get; set; } = new ObservableCollection<PostDto>();
        public ICommand InitCommand { get; set; }

        public RecommendedPostsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            try
            {
                PostsList.Clear();

                IList<PostModel> posts = await _postsService.Get<IList<PostModel>>(null, "recommended");

                foreach (var item in posts)
                {
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
    }
}
