namespace Shared.Domain.Models
{
    public record CurrentUser
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool HasRole(string role)
        {
            return Role == role;
        }
        public CurrentUser(bool isAuthenticated)
        {
            IsAuthenticated = isAuthenticated;
        }
        public CurrentUser(Guid UserId, string email, string Role, bool isAuthenticated)
        {
            this.UserId = UserId;
            this.Role = Role;
            Email = email;
            IsAuthenticated = isAuthenticated;
        }
    }
}
