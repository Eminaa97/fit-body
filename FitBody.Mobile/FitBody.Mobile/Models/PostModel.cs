using FitBody.Common.Contracts;
using System.Collections.ObjectModel;

namespace FitBody.Mobile.Models
{
    public class PostModel : PostDto
    {
        //public IList<CommentDto> Comments { get; set; }
        public ObservableCollection<CommentDto> Comments { get; set; }
    }
}
