using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExemploVersionamento.Configurations;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }
    }

    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {

        
        var info = new OpenApiInfo
        {
            Title = "Music API developed by Raul Cesar at DEV IN HOUSE V2",
            
        };

        if (description.IsDeprecated)
        {
           
            info.Title = "Music API developed by Raul Cesar at DEV IN HOUSE V1 ";
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}