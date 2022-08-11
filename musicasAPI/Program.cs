using ExemploVersionamento.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using musicasAPI.Contexts;
using musicasAPI.Repository.v1;
using musicasAPI.Repository.v2;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

#pragma warning disable CS8604
builder.Services.AddDbContext<MusicContext>(
    opcoes => opcoes.UseSqlServer(configuration.GetConnectionString("ConexaoDB")));
#pragma warning restore CS8604 
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(2, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-API-VERSION")
    );
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<AlbumRepository1>();
builder.Services.AddScoped<SingerRepository1>();
builder.Services.AddScoped<SongRepository1>();
builder.Services.AddScoped<AlbumRepository2>();
builder.Services.AddScoped<SingerRepository2>();
builder.Services.AddScoped<SongRepository2>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
       
        foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant()
            );
        }
    });
}

app.UseAuthorization();
app.UseCors(opcoes => opcoes.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
app.MapControllers();

app.Run();





