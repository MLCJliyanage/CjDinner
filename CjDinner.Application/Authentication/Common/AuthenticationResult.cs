using CjDinner.Domain.UserAggregate;

namespace CjDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);