using System;

namespace FitBody.Common.Contracts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Subcategoryname { get; set; }
        public string Categoryname { get; set; }
    }
}
