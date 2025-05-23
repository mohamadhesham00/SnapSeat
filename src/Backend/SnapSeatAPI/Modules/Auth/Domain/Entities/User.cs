﻿using Shared.Domain.Models;

namespace Auth.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";

        public List<RefreshToken> RefreshTokens { get; set; } = new();
    }
}
