using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("liked_posts")]
    public class PostLiked
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("post_id")]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
