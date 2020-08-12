namespace FitBody.Common.Contracts
{
    public class SubcategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        public override string ToString() => Title;

    }
}
