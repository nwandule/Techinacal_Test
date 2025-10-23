using Microsoft.AspNetCore.Identity;

namespace Demo_App.Repositories
{
    public interface ITokenRep
    {
        string CreateJWToken(IdentityUser user, List<string> roles);
    }
}
