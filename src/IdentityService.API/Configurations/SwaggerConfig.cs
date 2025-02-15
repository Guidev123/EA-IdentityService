﻿using Microsoft.OpenApi.Models;

namespace IdentityService.API.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "API Identidade",
                Description = "Esta é uma de autenticação de usuarios",
                Contact = new OpenApiContact() { Name = "Guilherme Nascimento", Email = "guirafaelrn@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/MIT") }
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token JWT desta forma: Bearer {seu token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
    }
}
