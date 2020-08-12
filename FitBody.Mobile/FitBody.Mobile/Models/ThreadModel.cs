using FitBody.Common.Contracts;
using System.Collections.ObjectModel;

namespace FitBody.Mobile.Models
{
    public class ThreadModel : ThreadDto
    {
        public ObservableCollection<CommentDto> Comments { get; set; }

    }
}
