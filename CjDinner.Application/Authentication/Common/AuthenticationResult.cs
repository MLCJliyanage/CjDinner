using CjDinner.Domain.Entities;

namespace CjDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);