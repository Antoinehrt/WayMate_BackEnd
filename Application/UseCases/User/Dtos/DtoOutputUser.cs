namespace Application.UseCases.User.Dtos.Dtos;

public class DtoOutputUser
{
    
     public int Id { get; set; }
     public string Username { get; set; }
     public string Password { get; set; }
     public string Email { get; set; }
     public string Birthdate { get; set; }
     public bool IsBanned { get; set; }
}