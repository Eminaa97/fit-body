using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("posts_tags")]
    public class PostTag
    {
        [Column("post_id")]
        public int PostId { get; set; }
        [Column("tag_id")]
        public int TagId { get; set; }

        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}
