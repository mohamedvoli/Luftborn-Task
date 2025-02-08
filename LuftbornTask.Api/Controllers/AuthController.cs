using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LuftbornTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularApp")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        //[HttpGet("get-token")]
        //public async Task<IActionResult> GetToken()
        //{
        //    string tenantId = _config["AzureAd:TenantId"];
        //    string clientId = _config["AzureAd:ClientId"];
        //    string clientSecret = _config["AzureAd:ClientSecret"];
        //    string authority = $"{_config["AzureAd:Instance"]}{tenantId}";
        //    var scopes = new string[] { "api://b13c224c-4755-409a-9f13-f2a52643b7c9/access_as_user" };


        //    var app = ConfidentialClientApplicationBuilder.Create(clientId)
        //        .WithClientSecret(clientSecret)
        //        .WithAuthority(new Uri(authority))
        //        .Build();

        //    var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

        //    return Ok(new { access_token = result.AccessToken });
        //}

        //[HttpGet("get-token")]
        //public async Task<IActionResult> GetToken([FromQuery] string authorizationCode)
        //{
        //    string tenantId = _config["AzureAd:TenantId"];
        //    string clientId = _config["AzureAd:ClientId"];
        //    string clientSecret = _config["AzureAd:ClientSecret"];
        //    string authority = $"{_config["AzureAd:Instance"]}{tenantId}";
        //    string redirectUri = "http://localhost:7264/signin-oidc";

        //    var scopes = new string[] { "api://b13c224c-4755-409a-9f13-f2a52643b7c9/access_as_user" };

        //    var app = ConfidentialClientApplicationBuilder.Create(clientId)
        //        .WithClientSecret(clientSecret)
        //        .WithAuthority(new Uri(authority))
        //        .WithRedirectUri(redirectUri)
        //        .Build();

        //    // Exchange authorization code for an access token
        //    var result = await app.AcquireTokenByAuthorizationCode(scopes, authorizationCode).ExecuteAsync();

        //    return Ok(new { access_token = result.AccessToken });
        //}
    }
}
