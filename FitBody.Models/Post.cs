using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("posts")]
    public class Post : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        [Column("date_modified")]
        public DateTime DateModified { get; set; }
        [Column("userID")]
        public int UserId { get; set; }
        [Column("subcategory_id")]
        public int SubcategoryId { get; set; }

        [ForeignKey(nameof(SubcategoryId))]
        public Subcategory Subcategory { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
