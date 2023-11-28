using System.Security.Claims;

namespace JWTAuthentication.Model
{
    public class UserModelRepositry
    {
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateOfJoing { get; set; }

        
    }
}
