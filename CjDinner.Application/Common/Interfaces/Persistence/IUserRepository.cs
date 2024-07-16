using CjDinner.Domain.UserAggregate;

namespace CjDinner.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);

}