using System.ComponentModel.DataAnnotations;
using Application.UseCases.Authentication;
using Application.UseCases.Authentication.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/authentication")]
public class AuthenticationControllers : ControllerBase {
    private readonly UseCaseLogin _useCaseLogin;

    public AuthenticationControllers(UseCaseLogin useCaseLogin) {
        _useCaseLogin = useCaseLogin;
    }

    [HttpGet]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputLogin> Login([Required] string email, [Required] string password) {
        try {
            if (string.IsNullOrWhiteSpace(password)) return BadRequest(); 
            return _useCaseLogin.Execute(email, password);
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }
    
}