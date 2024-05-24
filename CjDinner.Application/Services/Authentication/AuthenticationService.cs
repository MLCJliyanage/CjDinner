using CjDinner.Application.Common.Interfaces.Authentication;

namespace CjDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Login(string email, string password)
    {


        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstname",
            "lastname",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstname, string lastname, string email, string password)
    {
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstname, lastname);
        return new AuthenticationResult(
            userId,
            firstname,
            lastname,
            email,
            token
        );
    }
}