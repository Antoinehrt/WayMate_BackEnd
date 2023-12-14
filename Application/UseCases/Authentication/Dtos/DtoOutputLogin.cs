using Application.Services.TokenJWT;

namespace Application.UseCases.Authentication.Dtos; 

public class DtoOutputLogin {
    public string Token { get; set; }
    public bool IsLogged { get; set; }
}