using System;

namespace FitBody.Common.Contracts
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateModified { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }

    }
}
