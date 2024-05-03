
using Microsoft.AspNetCore.Identity;

namespace financas.Utils;

public class Hash<TUser>: IPasswordHasher<TUser>  where TUser : class
{
    public string HashPassword(TUser user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    }

    public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    {
        var valid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        if (!valid)
        {
            return PasswordVerificationResult.Failed;
        }
        return PasswordVerificationResult.Success;
    }
}