namespace BoxBack.Application.ViewModels.Requests
{
    public class AuthenticateViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}