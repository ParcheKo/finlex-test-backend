﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Orders.Api.Configuration;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Finlex Orders API",
                        Version = "v1",
                        Description =
                            "A simple ASP.NET DDD/CQRS example implemented based on the task definition provided by Mr. Shahrestani"
                    }
                );

                // todo: no description set yet for api controller actions.
                // var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                // var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                // options.IncludeXmlComments(commentsFile);
            }
        );

        return services;
    }

    internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "Finlex Orders API V1"
                );
            }
        );

        return app;
    }
}