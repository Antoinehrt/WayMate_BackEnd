using Application.Services.TokenJWT;
using Application.Services.TokenJWT.dto;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
/*
 * https://medium.com/@vndpal/how-to-implement-jwt-token-authentication-in-net-core-6-ab7f48470f5c
 * https://www.c-sharpcorner.com/article/jwt-token-creation-authentication-and-authorization-in-asp-net-core-6-0-with-po/
 * https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/
 */
[ApiController]
[Route("api/v1/users")]
public class TokenController {
    private readonly IConfiguration _configuration;
    private readonly TokenService _service;

    public TokenController(TokenService service, IConfiguration configuration) {
        _service = service;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult<DtoOutputToken> Auth(DtoInputToken dto) {
        var token = _service.BuildToken(
            _configuration["Jwt:Key"],
            _configuration["Jwt:Issuer"],
            dto);
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