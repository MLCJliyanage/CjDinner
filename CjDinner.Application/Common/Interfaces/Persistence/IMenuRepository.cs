using CjDinner.Domain.MenuAggregate;

namespace CjDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);
}