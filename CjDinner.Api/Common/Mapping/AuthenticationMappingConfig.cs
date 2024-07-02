using CjDinner.Application.Authentication.Commands.Register;
using CjDinner.Application.Authentication.Queries.Login;
using CjDinner.Application.Services.Authentication.Common;
using CjDinner.Contracts.Authentication;
using Mapster;

namespace CjDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}