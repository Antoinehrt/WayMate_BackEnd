using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.UseCases.Users.User.Dtos;

public class DtoInputCreateAdmin
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Email { get; set; }
    [Required] public DateTime Birthdate { get; set; }
    [Required] public bool IsBanned { get; set; }
    [Required] public string PhoneNumber { get; set; }
}