namespace StringR.Backend.Models
{
    public class UserForAccess
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public UserForAccess(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}