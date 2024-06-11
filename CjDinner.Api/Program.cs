using System.Reflection;
using CjDinner.Api.Common.Errors;
using CjDinner.Application;
using CjDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, CjDinnerProblemDetailsFactory>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}





