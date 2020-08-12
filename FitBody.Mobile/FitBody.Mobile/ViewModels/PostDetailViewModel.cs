using FitBody.Mobile.Models;

namespace FitBody.Mobile.ViewModels
{
    public class PostDetailViewModel : BaseViewModel
    {
        public PostModel Item { get; set; }
        public PostDetailViewModel(PostModel postModel = null)
        {
            Title = postModel?.Title;

            if (postModel != null)
            {
                Item = new PostModel
                {
                    Id = postModel.Id,
                    Categoryname = postModel.Categoryname,
                    Username= postModel.Username,
                    UserId = postModel.UserId,
                    Content = postModel.Content,
                    CategoryId = postModel.CategoryId,
                    Comments = postModel.Comments,
                    DateCreated = postModel.DateCreated,
                    DateModified = postModel.DateModified,
                    SubcategoryId = postModel.SubcategoryId,
                    Subcategoryname = postModel.Subcategoryname,
                    Title = postModel.Title
                };
            }
        }
    }
}
