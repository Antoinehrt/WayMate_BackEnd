using Application.Services.TokenJWT;

namespace Application.UseCases.Authentication.Dtos; 

public class DtoOutputLogin {
    public bool IsLogged { get; set; }
}