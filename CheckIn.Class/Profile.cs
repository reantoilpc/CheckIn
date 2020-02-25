namespace CheckIn.Class
{
    public class Profile
    {
        public bool Exist => AccountId > 0;
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
    }
}