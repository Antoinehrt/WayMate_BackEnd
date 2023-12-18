using System.ComponentModel.DataAnnotations;
using Api.Controllers.Users;
using Application.Services.TokenJWT;
using Application.Services.TokenJWT.dto;
using Application.UseCases.Authentication;
using Application.UseCases.Authentication.Dtos;
using Application.UseCases.Users.Passenger;
using Application.UseCases.Users.Passenger.Dto;
using Application.UseCases.Users.User;
using Application.UseCases.Users.User.Dto;
using Domain.Enums;
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
    private readonly UseCaseCreatePassenger _useCaseCreatePassenger;
    

    public AuthenticationControllers(UseCaseLogin useCaseLogin, UseCaseRegistrationEmail useCaseRegistrationEmail, UseCaseRegistrationUsername useCaseRegistrationUsername, TokenService tokenService, IConfiguration configuration, UserCaseFetchUserByEmail userCaseFetchUserByEmail, UseCaseCreatePassenger useCaseCreatePassenger)
    {
        _useCaseLogin = useCaseLogin;
        _useCaseRegistrationEmail = useCaseRegistrationEmail;
        _useCaseRegistrationUsername = useCaseRegistrationUsername;
        _tokenService = tokenService;
        _configuration = configuration;
        _userCaseFetchUserByEmail = userCaseFetchUserByEmail;
        _useCaseCreatePassenger = useCaseCreatePassenger;
    }
    
    [AllowAnonymous]
    [HttpGet("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputToken> Login([FromQuery][Required] string email, [FromQuery][Required] string password) {
        try {
            var authResult = _useCaseLogin.Execute(email, password); 
            if (!authResult.isLogged) {
                return BadRequest("Wrong credentials");
            }
            return Ok(GenerateAndSetToken(new DtoInputToken{username = authResult.username, userType = authResult.usertype}));
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }

    [AllowAnonymous]
    [HttpPost("registration")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputPassenger> Registration(DtoInputCreatePassenger dto) {
            var registrationResult = _useCaseCreatePassenger.Execute(dto);
            GenerateAndSetToken(new DtoInputToken
                { username = registrationResult.Username, userType = registrationResult.UserType });
            return Ok(registrationResult);
    }
    
    [HttpPost("token")]
    public DtoOutputToken GenerateAndSetToken(DtoInputToken dto) {
        var token = _tokenService.BuildToken(_configuration["JWT:Key"], _configuration["JWT:Issuer"], dto);
        HttpContext.Response.Cookies.Append("WayMateToken", token, new CookieOptions {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None,
            MaxAge = TimeSpan.FromHours(2),
            IsEssential = true, 
        });

        return new DtoOutputToken {
            token = token
        };
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

    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public ActionResult TestConnection() {
        var identityName = User.Identity.Name;
        Console.Write(identityName);
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
    
}