namespace CheckIn.Class
{
    public class Profile
    {
        public bool Exist => AccountID > 0;
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
    }
}