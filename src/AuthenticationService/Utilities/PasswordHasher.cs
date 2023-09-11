using System.Security.Cryptography;

namespace AuthenticationService.Utilities;
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    public static string HashPassword(string password)
    {
        byte[] salt = GenerateSalt();
        byte[] hash = HashPassword(password, salt);
        byte[] saltedHash = new byte[SaltSize + HashSize];

        Array.Copy(salt, 0, saltedHash, 0, SaltSize);
        Array.Copy(hash, 0, saltedHash, SaltSize, HashSize);

        return Convert.ToBase64String(saltedHash);
    }

    public static bool ValidatePassword(string password, string hashedPassword)
    {
        byte[] saltedHash = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[SaltSize];
        byte[] hash = new byte[HashSize];

        Array.Copy(saltedHash, 0, salt, 0, SaltSize);
        Array.Copy(saltedHash, SaltSize, hash, 0, HashSize);

        byte[] computedHash = HashPassword(password, salt);

        return SlowEquals(hash, computedHash);
    }

    private static byte[] HashPassword(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(HashSize);
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
}