using System.Security.Authentication;
using System.Security.Claims;
using Application.Services.TokenJWT;
using Application.Services.TokenJWT.dto;
using Domain.Entities.Users;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/token")]
public class TokenController : ControllerBase {
    private readonly IConfiguration _configuration;
    private readonly TokenService _tokenService;

    public TokenController(TokenService tokenService, IConfiguration configuration) {
        _tokenService = tokenService;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult<DtoOutputToken> Auth(DtoInputToken dto) {
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
}