using Domain.Enums;

namespace Application.Services.TokenJWT.dto; 

public class DtoInputToken {
    public string Username { get; set; }
    public UserType UserType { get; set; }
    public string Password { get; set; }
}
