using CjDinner.Application.Common.Interfaces.Authentication;
using CjDinner.Application.Common.Interfaces.Persistence;
using CjDinner.Application.Services.Authentication.Common;
using CjDinner.Domain.Entities;
using CjDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using CjDinner.Application.Authentication.Queries.Login;

namespace CjDinner.Application.Authentication.Commands.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredential;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}