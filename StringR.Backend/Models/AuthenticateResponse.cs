namespace StringR.Backend.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; }
        public int Id { get; }
        public string ResponseMessage { get; }

        public AuthenticateResponse(string token, int id, string responseMessage = null)
        {
            Token = token;
            Id = id;
            ResponseMessage = responseMessage;
        }
    }
}