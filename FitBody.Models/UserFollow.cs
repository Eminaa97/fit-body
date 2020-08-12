using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("user_follows")]
    public class UserFollow
    {
        [Column("user_following_id")]
        public int UserFollowingId { get; set; }
        [Column("user_followed_id")]
        public int UserFollowedId { get; set; }

        [ForeignKey(nameof(UserFollowedId))]
        public User UserFollowed { get; set; }

        [ForeignKey(nameof(UserFollowingId))]
        public User UserFollowing { get; set; }
    }
}
