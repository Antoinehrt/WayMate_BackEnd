using System.ComponentModel.DataAnnotations;
using Application.Services.TokenJWT;
using Application.Services.TokenJWT.dto;
using Application.UseCases.Authentication;
using Application.UseCases.Authentication.Dtos;
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
    [HttpGet("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputLogin> Login([FromQuery][Required] string email, [FromQuery][Required] string password) {
        try {
            var authResult = _useCaseLogin.Execute(email, password); 
            if (!authResult.isLogged) {
                return BadRequest("Wrong credentials");
            }
            return authResult;
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }
    
    [AllowAnonymous]
    [HttpGet("token")]
    public DtoOutputToken GenerateAndSetToken([FromQuery][Required]string username, [FromQuery][Required]string userType) {
        var dto = new DtoInputToken { Username = username, UserType = userType };
        var token = _tokenService.BuildToken(_configuration["JWT:Key"], _configuration["JWT:Issuer"], dto);
        
        Response.Cookies.Append("WayMateToken", token, new CookieOptions {
            Secure = true,
            HttpOnly = false,
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

    /*
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
    */
}