using System;

namespace FitBody.Desktop.Models
{
    public class PostDataGrid
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string User { get; set; }
        public string Subcategory { get; set; }
        public int UserId { get; set; }
    }
}
