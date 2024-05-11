namespace FSMS.Auth
{
    public class UserSession
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
    }
}
