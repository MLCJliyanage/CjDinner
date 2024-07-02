using CjDinner.Api.Common.Errors;
using CjDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CjDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CjDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}