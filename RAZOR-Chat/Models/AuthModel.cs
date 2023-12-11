using System.Text.Json.Serialization;

namespace RAZOR_Chat.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateOnly DOB { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string? Hashedpassword { get; set; }
    }
    
}
