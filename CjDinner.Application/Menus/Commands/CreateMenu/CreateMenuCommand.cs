using CjDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace CjDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand
(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections,
    float? AverageRating
) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand
(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand
(
    string Name,
    string Description
);