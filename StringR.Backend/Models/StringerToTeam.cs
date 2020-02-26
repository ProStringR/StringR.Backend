namespace StringR.Backend.Models
{
    public class StringerToTeam
    {
        public int TeamId { get; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PreferredRacketType { get; set; }

        public StringerToTeam(int teamId, string firstname, string lastName, string phoneNumber, string email, int preferredRacketType)
        {
            TeamId = teamId;
            Firstname = firstname;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            PreferredRacketType = preferredRacketType;
        }
    }
}