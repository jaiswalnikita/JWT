namespace Intershall.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string Roles{ get; set; }
        public string Isactive { get; set; }
        public string Token { get; set; }

    }
}
