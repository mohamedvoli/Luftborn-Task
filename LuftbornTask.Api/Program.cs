using FluentValidation;
using FluentValidation.AspNetCore;
using LuftbornTask.Application;
using LuftbornTask.Domain.Entities;
using LuftbornTask.Domain.Interfaces;
using LuftbornTask.Infrastructure.Persistence;
using LuftbornTask.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepo<>));

builder.Services.AddApplication();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:59129") // Replace with your Angular app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


#region Auth configeration
var initialScopes = builder.Configuration["AzureAd:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
    .AddInMemoryTokenCaches();

#endregion

#region OLD CODE
//var azureAdSettings = builder.Configuration.GetSection("AzureAd");
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.Authority = $"{azureAdSettings["Instance"]}{azureAdSettings["TenantId"]}/v2.0";
//        options.Audience = azureAdSettings["Audience"];
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = $"https://sts.windows.net/{azureAdSettings["TenantId"]}/",
//            ValidateAudience = true,
//            ValidAudience = azureAdSettings["Audience"],
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true
//        };
//    })
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
//        .EnableTokenAcquisitionToCallDownstreamApi()
//            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
//            .AddInMemoryTokenCaches();
//builder.Services.AddAuthorization(//options =>
////{
//    //options.AddPolicy("AccessAsUser", policy =>
//        //policy.RequireAuthenticatedUser()
//           //   .RequireClaim("scp", "access_as_user")); // Ensure scope is required
////}
//);

//Configure Swagger for Authentication

//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//    {
//        Description = "Enter 'Bearer {your_token}'",
//        Name = "Authorization",
//        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
//        Scheme = "bearer"
//    });

//    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//    {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//            {
//                Reference = new Microsoft.OpenApi.Models.OpenApiReference
//                {
//                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            new string[] { }
//        }
//    });
//});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAngularApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
