using System.ComponentModel.DataAnnotations;
using Application.UseCases.Authentication;
using Application.UseCases.Authentication.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/authentication")]
public class AuthenticationControllers : ControllerBase {
    private readonly UseCaseLogin _useCaseLogin;
    private readonly UseCaseFetchByEmailRegistration _useCaseFetchByEmailRegistration;
    private readonly UseCaseFetchByUsernameRegistration _useCaseFetchByUsernameRegistration;
    

    public AuthenticationControllers(UseCaseLogin useCaseLogin, UseCaseFetchByUsernameRegistration useCaseFetchByUsernameRegistration, UseCaseFetchByEmailRegistration useCaseFetchByEmailRegistration)
    {
        _useCaseLogin = useCaseLogin;
        _useCaseFetchByUsernameRegistration = useCaseFetchByUsernameRegistration;
        _useCaseFetchByEmailRegistration = useCaseFetchByEmailRegistration;
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

    [HttpGet]
    [Route("{email:regex(^[[a-z0-9]]+(?:.[[a-z0-9]]+)*@(?:[[a-z0-9]](?:[[a-z0-9-]]*[[a-z0-9]])?.)+[[a-z0-9]](?:[[a-z0-9-]]*[[a-z0-9]])?$)}")]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputRegistration> FetchByEmail(string email)
    {
        try
        {
            return _useCaseFetchByEmailRegistration.Execute(email);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpGet]
    [Route("{username:regex(^[[a-zA-Z0-9_-]]${{3,16}})}")]
    [ProducesResponseTypeAttribute(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DtoOutputRegistration> FetchByUsername(string username)
    {
        try
        {
            return _useCaseFetchByUsernameRegistration.Execute(username);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
}