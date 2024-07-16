using CjDinner.Application.Common.Interfaces.Persistence;
using CjDinner.Domain.HostAggregate.ValueObjects;
using CjDinner.Domain.MenuAggregate;
using CjDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CjDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            request.Name,
            request.Description,
            HostId.Create(request.HostId),
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );

        _menuRepository.Add(menu);

        return menu;
    }
}