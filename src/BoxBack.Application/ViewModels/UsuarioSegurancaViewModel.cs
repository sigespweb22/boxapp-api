namespace BoxBack.Application.ViewModels
{
    public class UsuarioSegurancaViewModel
    {
        public string Id { get;set; }
        public string CurrentPassword { get;set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}