using System;

namespace FitBody.Common.Requests
{
    public class UserInsertRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mobile { get; set; }
        public string Info { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Image { get; set; }
        public int Permission { get; set; }
    }
}
