namespace AspNet.NoMvc.Mvc5.Sample.Accounts
{
    public class LogOnModel
    {
        public string ReturnUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}