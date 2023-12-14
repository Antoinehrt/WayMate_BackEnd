using Domain.Enums;

namespace Application.Services.TokenJWT.dto; 

public class DtoInputToken {
    public string Username { get; set; }
    public string UserType { get; set; }
}
