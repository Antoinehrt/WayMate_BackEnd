using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Authentication.Dtos;

public class DtoInputLogin {
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}