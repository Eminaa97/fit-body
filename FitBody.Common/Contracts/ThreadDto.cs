using System;
using System.Collections.Generic;
using System.Text;

namespace FitBody.Common.Contracts
{
    public class ThreadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
