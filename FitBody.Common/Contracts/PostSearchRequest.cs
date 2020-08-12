using System;
using System.Collections.Generic;
using System.Text;

namespace FitBody.Common.Contracts
{
    public class PostSearchRequest
    {
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
    }
}
