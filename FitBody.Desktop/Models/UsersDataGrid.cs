namespace FitBody.Desktop.Models
{
    public class UsersDataGrid
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int Permission { get; set; }
    }
}
