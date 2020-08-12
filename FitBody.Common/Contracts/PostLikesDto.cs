using System;
using System.Collections.Generic;
using System.Text;

namespace FitBody.Common.Contracts
{
    public class PostLikesDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public int Likes { get; set; }
    }
}
