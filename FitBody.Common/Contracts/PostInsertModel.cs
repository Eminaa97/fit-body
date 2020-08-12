using System.Collections.Generic;

namespace FitBody.Common.Contracts
{
    public class PostInsertModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int SubcategoryId { get; set; }
        public IList<string> Tags { get; set; }
    }

    public class PostUpdateModel : PostInsertModel
    {
        public int Id { get; set; }
    }

}
