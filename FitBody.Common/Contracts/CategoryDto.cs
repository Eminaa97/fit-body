namespace FitBody.Common.Contracts
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString() => Title;
    }
}
