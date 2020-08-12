using System.Runtime.Serialization;

namespace FitBody.Common.Requests
{
    public class UserSearchRequest
    {
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastname")]
        public string LastName{ get; set; }
        [DataMember(Name = "username")]
        public string UserName{ get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}
