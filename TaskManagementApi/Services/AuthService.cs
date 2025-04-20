using TaskManagementApi.Models;
using TaskManagementApi.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace TaskManagementApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public User ValidateUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            if (!VerifyPassword(password, user.PasswordHash))
                return null;

            return user;
        }

        public User RegisterUser(string email, string password)
        {
            if (_context.Users.Any(u => u.Email == email))
                return null;

            var passwordHash = HashPassword(password);
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: new byte[128 / 8],  // Random salt would typically be used
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return storedHash == hash;
        }
    }
}
