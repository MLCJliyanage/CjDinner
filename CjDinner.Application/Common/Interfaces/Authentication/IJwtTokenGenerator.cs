using CjDinner.Domain.UserAggregate;

namespace CjDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}