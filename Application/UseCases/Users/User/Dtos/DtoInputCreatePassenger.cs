using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.UseCases.Users.User.Dtos;

public class DtoInputCreatePassenger
{
    [Required] public string Username { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Email { get; set; }
    [Required] public DateTime Birthdate { get; set; }
    [Required] public bool IsBanned { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [AllowNull] public string LastName { get; set; }
    [AllowNull] public string FirstName { get; set; }
    [AllowNull] public string Gender { get; set; }
    public int AddressId { get; set; }
}