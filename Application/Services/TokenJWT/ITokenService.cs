using Application.Services.TokenJWT.dto;

namespace Application.Services.TokenJWT; 

public interface ITokenService {
    public string BuildToken(string key, string issuer, DtoInputToken token);
    public bool IsTokenValid(string key, string issuer, string token);
}