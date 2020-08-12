namespace FitBody.Mobile.Models
{
    public enum MenuItemType
    {
        RecommendedPosts,
        Posts,
        Users,
        FitBlog,
        TopicsSuggested,
        FitForum,
        Logout,
        EditProfile
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
