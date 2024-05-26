using CjDinner.Domain.Entities;

namespace CjDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);