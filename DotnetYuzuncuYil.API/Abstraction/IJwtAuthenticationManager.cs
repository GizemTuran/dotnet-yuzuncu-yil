using DotnetYuzuncuYil.Core.DTOs;

namespace DotnetYuzuncuYil.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string username, string password);
    }
}
