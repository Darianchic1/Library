using Microsoft.AspNetCore.Identity;

public interface ITokenService
{
    string CreateToken(User user, List<IdentityRole<long>> role);
}