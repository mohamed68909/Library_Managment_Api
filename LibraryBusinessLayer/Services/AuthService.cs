using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using LiibraryDataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer.Services
{

    public class AuthService : IAuthService
    {
        private readonly LibraryContext _context;
        private readonly IConfiguration _config;

        public AuthService(LibraryContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task RegisterAsync(UserRegisterDto dto)
        {
            if ( await _context.Users.AnyAsync(u => u.Username == dto.Username))
                throw new Exception("Username already exists");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Name = dto.Name,
                ContactInformation = dto.ContactInformation,
                LibraryCardNumber = dto.LibraryCardNumber,
                Username = dto.Username,
                PasswordHash = hashedPassword
            };

           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Login data is incorrect");

            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserID", user.UserId.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}