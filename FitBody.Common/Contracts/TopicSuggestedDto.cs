using System;

namespace FitBody.Common.Contracts
{
    public class TopicSuggestedDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Topic { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
