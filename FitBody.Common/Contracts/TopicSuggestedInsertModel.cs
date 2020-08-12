using System;
using System.Collections.Generic;
using System.Text;

namespace FitBody.Common.Contracts
{
    public class TopicSuggestedInsertModel
    {
        public int UserId { get; set; }
        public string Topic { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
