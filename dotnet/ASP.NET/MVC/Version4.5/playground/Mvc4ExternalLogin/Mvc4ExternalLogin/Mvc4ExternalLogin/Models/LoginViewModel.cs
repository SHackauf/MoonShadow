namespace Mvc4ExternalLogin.Models
{
    public class LoginViewModel
    {
        public LoginViewModel(string info = "")
        {
            Info = info;
        }

        public string Info { get; set; }
    }
}