using System.ComponentModel.DataAnnotations;
using Application.Services.TokenJWT;
using Application.Services.TokenJWT.dto;
using Application.UseCases.Authentication;
using Application.UseCases.Authentication.Dtos;
using Application.UseCases.Users.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/authentication")]
public class AuthenticationControllers : ControllerBase {
    private readonly UseCaseLogin _useCaseLogin;
    private readonly UseCaseRegistrationEmail _useCaseRegistrationEmail;
    private readonly UseCaseRegistrationUsername _useCaseRegistrationUsername;
    private readonly IConfiguration _configuration;
    private readonly TokenService _tokenService;
    private readonly UserCaseFetchUserByEmail _userCaseFetchUserByEmail;
    

    public AuthenticationControllers(UseCaseLogin useCaseLogin, UseCaseRegistrationEmail useCaseRegistrationEmail, UseCaseRegistrationUsername useCaseRegistrationUsername, TokenService tokenService, IConfiguration configuration, UserCaseFetchUserByEmail userCaseFetchUserByEmail)
    {
        _useCaseLogin = useCaseLogin;
        _useCaseRegistrationEmail = useCaseRegistrationEmail;
        _useCaseRegistrationUsername = useCaseRegistrationUsername;
        _tokenService = tokenService;
        _configuration = configuration;
        _userCaseFetchUserByEmail = userCaseFetchUserByEmail;
    }
    
    
    [AllowAnonymous]
    [HttpPost]
    public DtoOutputToken Auth(DtoInputToken dto) {
        var token = _tokenService.BuildToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], dto);
        Response.Cookies.Append("cookie", token, new CookieOptions {
            Secure = true,
            HttpOnly = true
        });
        return new DtoOutputToken {
            Token = token
        };
    }
 
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult TestConnectionAdmin() {
        return Ok(new {
            text = "Ok"
        });
    }
    [HttpGet]
    [Authorize(Roles = "Passenger")]
    public ActionResult TestConnectionPassenger() {
        return Ok(new {
            text = "Ok"
        });
    }
    [HttpGet]
    [Authorize(Roles = "Driver")]
    public ActionResult TestConnectionDriver() {
        return Ok(new {
            text = "Ok"
        });
    }
    [HttpGet]
    [Authorize]
    [Route("IsConnected")]
    public ActionResult IsConnected() {
        return Ok();
    }

    [HttpGet("login")]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DtoOutputLogin>> Login([FromQuery][Required] string email, [FromQuery][Required] string password) {
        try {
            var user = _userCaseFetchUserByEmail.Execute(email);
            if (string.IsNullOrWhiteSpace(password)) return BadRequest();
            if (_useCaseLogin.Execute(email, password).IsLogged) {
                return new DtoOutputLogin {
                    Token = Auth(new DtoInputToken { Username = user.Username, UserType = user.UserType }).Token,
                    IsLogged = true
                };
            }

            return Unauthorized("Connection failed.");
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }
    
    [HttpGet("registration/by-email/{email:regex(^[[a-z0-9]]+(?:.[[a-z0-9]]+)*@(?:[[a-z0-9]](?:[[a-z0-9-]]*[[a-z0-9]])?.)+[[a-z0-9]](?:[[a-z0-9-]]*[[a-z0-9]])?$)}")]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputRegistration> FetchByEmail(string email) {
        return _useCaseRegistrationEmail.Execute(email);
    }
    
    [HttpGet("registration/by-username/{username:regex(^[[a-zA-Z0-9_-]]{{5,20}}$)}")]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputRegistration> FetchByUsername(string username) {
        return _useCaseRegistrationUsername.Execute(username);
    }
    
}