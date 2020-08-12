using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FitBody.Models
{
    [Table("post_comments")]
    public class PostComment
    {
        [Column("post_id")]
        [ForeignKey (nameof(PostId))]
        public int PostId { get; set; }

        [ForeignKey (nameof(CommentId))]
        [Column("comment_id")]
        public int CommentId { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}
