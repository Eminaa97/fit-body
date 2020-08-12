using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("saved_posts")]
    public class PostSaved
    {

        [Column("user_id")]
        public int UserId { get; set; }
        [Column("post_id")]
        public int PostId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
