using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FitBody.Models
{
    [Table("thread_comments")]
    public class ThreadComment
    {
        [Column("thread_id")]
        [ForeignKey(nameof(ThreadId))]
        public int ThreadId { get; set; }

        [ForeignKey(nameof(CommentId))]
        [Column("comment_id")]
        public int CommentId { get; set; }
        public Thread Thread { get; set; }
        public Comment Comment { get; set; }
    }
}
