namespace StringR.Backend.Models
{
    public class UserForAcces
    {

        public string userName { get; set; }
        public string password { get; set; }

        public UserForAcces(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}