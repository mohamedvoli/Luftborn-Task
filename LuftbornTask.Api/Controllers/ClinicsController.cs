using LuftbornTask.Application.Features.Clinic.Commands;
using LuftbornTask.Application.Features.Clinic.Queries;
using LuftbornTask.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace LuftbornTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EnableCors("AllowAngularApp")]
    public class ClinicsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBaseRepository<Domain.Entities.Clinic> _baseRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public ClinicsController(IMediator mediator, IBaseRepository<Domain.Entities.Clinic> baseRepository,
            HttpClient httpClient, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _mediator = mediator;
            _baseRepository = baseRepository;
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

    //    [HttpGet("login")]
    //    [AllowAnonymous]
    //    public IActionResult Login()
    //    {
    //        var instance = _configuration["AzureAd:Instance"];
    //        var tenantId = _configuration["AzureAd:TenantId"];
    //        var clientId = _configuration["AzureAd:ClientId"];
    //        var redirectUri = "https://localhost:7264/api/Clinics/callback"; // Must match Azure portal settings

    //        var authUrl = $"{instance}{tenantId}/oauth2/v2.0/authorize?" +
    //                      $"client_id={clientId}" +
    //                      $"&response_type=code" +
    //                      $"&redirect_uri={redirectUri}" +
    //                      $"&response_mode=query" +
    //                      $"&scope=openid profile email" +
    //                      $"&state=12345";

    //        return Redirect(authUrl);
    //    }

    //    [HttpGet("callback")]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Callback([FromQuery] string code)
    //    {
    //        if (string.IsNullOrEmpty(code))
    //        {
    //            return BadRequest("Authorization code is missing.");
    //        }

    //        var tokenEndpoint = "https://login.microsoftonline.com/organizations/oauth2/v2.0/token";
    //        var client = _httpClientFactory.CreateClient();

    //        var parameters = new Dictionary<string, string>
    //{
    //    { "client_id", _configuration["AzureAd:ClientId"] },
    //    { "client_secret", _configuration["AzureAd:ClientSecret"] },
    //    { "grant_type", "authorization_code" },
    //    { "code", code },
    //    { "redirect_uri", "https://localhost:7264/api/Clinics/callback" }, // Must match the Azure AD app settings
    //    { "scope", "openid profile email" }
    //};

    //        var content = new FormUrlEncodedContent(parameters);
    //        var response = await client.PostAsync(tokenEndpoint, content);

    //        if (!response.IsSuccessStatusCode)
    //        {
    //            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
    //        }

    //        var tokenResponse = await response.Content.ReadAsStringAsync();
    //        return Ok(tokenResponse); // Returns the access token
    //    }


        // GET api/clinics
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var clinics = await _mediator.Send(new GetAllClinicsQuery());
            return Ok(clinics);
        }

        // GET api/clinics/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var clinic = await _mediator.Send(new GetClinicByIdQuery { Id = id });
            return Ok(clinic);
        }

        [ProducesResponseType(200, Type = typeof(int))]
        // POST api/clinics/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateClinicCommand command)
        {
            var clinicId = await _mediator.Send(command);
            return Ok(clinicId);
        }

        // PUT api/clinics/update
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateClinicCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/clinics/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteClinicCommand { Id = id });
            return NoContent();
        }
    }
}
