using FitBody.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitBody.Mobile.ViewModels
{
    public class TopicsSuggestedViewModel: BaseViewModel
    {
        private readonly ApiService _topicsService = new ApiService("topicsSuggested");

        public ObservableCollection<TopicSuggestedDto> TopicsSuggestedList { get; set; } = new ObservableCollection<TopicSuggestedDto>();

        public ICommand InitCommand { get; set; }

        public TopicsSuggestedViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            try
            {
                TopicsSuggestedList.Clear();
                var users = await _topicsService.Get<IList<TopicSuggestedDto>>(null,$"user/{ApiService.LoggedInUserId}");

                foreach (var item in users)
                {
                    TopicsSuggestedList.Add(item);
                }

            }
            catch
            {
                throw;
            }
        }

    }
}
