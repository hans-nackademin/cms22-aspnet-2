using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Models.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public byte[] Password { get; private set; } = null!;
    public byte[] SecurityKey { get; private set; } = null!;

    public void GenerateSecurePassword(string password)
    {
        using var hmac = new HMACSHA512();
        SecurityKey = hmac.Key;
        Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public bool ValidateSecurePassword(string password)
    {
        using var hmac = new HMACSHA512(SecurityKey);
        var _password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for(int i = 0; i < Password.Length; i++)
            if (_password[i] != Password[i])
                return false;

        return true;
    }
}
