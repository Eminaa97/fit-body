using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("threads")]
    public class Thread: IEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column ("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
