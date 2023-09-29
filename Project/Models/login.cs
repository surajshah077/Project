using Project.Models.Enum;

namespace Project.Models
{
    public class login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }  
    }
}
