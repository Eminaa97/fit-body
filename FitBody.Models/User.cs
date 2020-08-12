using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitBody.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("mobile")]
        public string Mobile { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("password_hash")]
        public string PasswordHash { get; set; }
        [Column("password_salt")]
        public string PasswordSalt { get; set; }
        [Column("image")]
        public string Image { get; set; }
        [Column("info")]
        public string Info { get; set; }
        [Column("height")]
        public float Height { get; set; }
        [Column("weight")]
        public float Weight { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("permission")]
        public int Permission { get; set; }
        [Column("active")]
        public bool Active { get; set; }

    }
}
