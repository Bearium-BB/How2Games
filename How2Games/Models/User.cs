namespace How2Games.Models
{
    public class User
    {
        public int Id { get; set; }
        private string _FullName { get; set; }
        public string UserName { get; set; }
        private string _Email { get; set; }
        private string _Password { get; set; }
    }
}
