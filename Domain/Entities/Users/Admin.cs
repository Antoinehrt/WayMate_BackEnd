using Domain.Entities.Users;


namespace Domain;

public class Admin : User{
    public string AdminRole { get; set; }
}