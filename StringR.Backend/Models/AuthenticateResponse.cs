namespace StringR.Backend.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; }
        public int Id { get; }
        public string ResponseMessage { get; }
        
        public int TeamId { get; }

        public AuthenticateResponse(string token, int id, int teamId, string responseMessage = null)
        {
            Token = token;
            Id = id;
            TeamId = teamId;
            ResponseMessage = responseMessage;
        }
    }
}