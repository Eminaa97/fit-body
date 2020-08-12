namespace FitBody.Common.Contracts
{
    public class CommentInsertModel
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? ThreadId { get; set; }
    }
}
