namespace projectDB.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}
