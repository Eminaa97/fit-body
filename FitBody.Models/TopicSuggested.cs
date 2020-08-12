using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("suggested_topics")]
    public class TopicSuggested : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("topic")]
        public string Topic { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
