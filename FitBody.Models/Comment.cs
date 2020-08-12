using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("comments")]
    public class Comment : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("date_posted")]
        public DateTime DatePosted { get; set; }
        [Column("date_modified")]
        public DateTime DateModified { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
