using FitBody.Common.Contracts;
using FitBody.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FitBody.Mobile.ViewModels
{
    public class FitForumViewModel:BaseViewModel
    {
        private readonly ApiService _threadService = new ApiService("threads");
        private readonly ApiService _commentsService = new ApiService("comments");

        public ObservableCollection<ThreadModel> ThreadsList { get; set; } = new ObservableCollection<ThreadModel>();
        public ICommand InitCommand { get; set; }

        public FitForumViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            try
            {
                ThreadsList.Clear();

                IList<ThreadModel> posts = null;

                posts = await _threadService.Get<IList<ThreadModel>>();
                

                foreach (var item in posts)
                {
                    var data = await _commentsService.Get<IList<CommentDto>>(null, $"threads/{item.Id}");
                    item.Comments = new ObservableCollection<CommentDto>(data);
                    ThreadsList.Add(item);
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
                var threadSearch = await _threadService.Post<IList<ThreadModel>>(new ThreadSearchRequest
                {
                    Title = Title
                }, "search");
                ThreadsList.Clear();

                foreach (var item in threadSearch)
                {
                    ThreadsList.Add(item);
                    item.Comments = new ObservableCollection<CommentDto>();

                    var comments = await _commentsService.Get<IList<CommentDto>>(null,$"threads/{item.Id}");
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
