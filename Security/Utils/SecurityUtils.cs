namespace Security.Utils;

public class SecurityUtils
{
    public static string HashString(string plain)
    {
        return BCrypt.Net.BCrypt.HashPassword(plain);
    }

    public static bool VerifyHash(string plain, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(plain, hash);
    }
}