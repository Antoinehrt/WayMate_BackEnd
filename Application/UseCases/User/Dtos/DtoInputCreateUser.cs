using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.User.Dtos.Dtos;

public class DtoInputCreateUser
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Birthdate { get; set; }
    [Required] public bool IsBanned { get; set; }
}