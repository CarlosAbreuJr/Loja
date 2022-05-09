using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Loja.API.Middleware
{
    public static class MiddlewareSwaggerExt
    {
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo 
				{ 
					Title = "Loja.API", 
					Version = "v1",
					Description = "Api destinada a MVP mini-loja em angular.",
					Contact = new OpenApiContact
					{
						Name = "Carlos Bernardes de Abreu Júnior",
						Url = new Uri("https://br.linkedin.com/in/carlos-abreu-jr"),
					},
					License = new OpenApiLicense
					{
						Name = "MIT",
					},
				});
				c.SwaggerDoc("v2", new OpenApiInfo
				{
					Title = "Loja.API",
					Version = "v2",
					Description = "Api destinada a MVP mini-loja em angular(Apenas para demonstrar o versionamento).",
					Contact = new OpenApiContact
					{
						Name = "Carlos Bernardes de Abreu Júnior",
						Url = new Uri("https://br.linkedin.com/in/carlos-abreu-jr"),
					},
					License = new OpenApiLicense
					{
						Name = "MIT",
					},
				});
				c.SwaggerDoc("v3", new OpenApiInfo
				{
					Title = "Loja.API",
					Version = "v3",
					Description = "Api destinada a MVP mini-loja em angular(Mescla da versão 1 com a versão 2 no cadastro de usuário).",
					Contact = new OpenApiContact
					{
						Name = "Carlos Bernardes de Abreu Júnior",
						Url = new Uri("https://br.linkedin.com/in/carlos-abreu-jr"),
					},
					License = new OpenApiLicense
					{
						Name = "MIT",
					},
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "JSON Web Token. Example: Bearer {token}",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
						},
						new [] { string.Empty }
					}
				});
			});

			services.AddApiVersioning(options =>
			{
				// Retorna os headers "api-supported-versions" e "api-deprecated-versions"
				// indicando versões suportadas pela API e o que está como deprecated
				options.ReportApiVersions = true;

				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(2, 1);
			});

			services.AddVersionedApiExplorer(options =>
			{
				// Agrupar por número de versão
				options.GroupNameFormat = "'v'VVV";

				// Necessário para o correto funcionamento das rotas
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}

		public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => {
				foreach (var description in provider.ApiVersionDescriptions)
				{
					c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
						$"Loja.API {description.GroupName.ToUpperInvariant()}");
					c.DocumentTitle = $"Api da Loja {description.GroupName.ToUpperInvariant()}";
				}
			});

			//app.UseSwagger().UseSwaggerUI(options =>
			//{
			//	options.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT API");
			//	options.DocumentTitle = "JWT API";
			//});

			return app;
		}

	}
}
