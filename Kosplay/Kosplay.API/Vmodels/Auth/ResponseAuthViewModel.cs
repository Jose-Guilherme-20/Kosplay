namespace Kosplay.API.Vmodels.Auth
{
    public class ResponseAuthViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int Expiration { get; set; }

    }
}
