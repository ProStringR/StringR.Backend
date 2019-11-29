namespace StringR.Backend.Models
{
    public class StringerToTeam
    {
        public int TeamId { get; }
        public string Firstname { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public int PreferredRacketType { get; }

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