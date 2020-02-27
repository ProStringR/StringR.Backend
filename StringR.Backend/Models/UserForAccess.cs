namespace StringR.Backend.Models
{
    public class UserForAccess
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserForAccess(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}