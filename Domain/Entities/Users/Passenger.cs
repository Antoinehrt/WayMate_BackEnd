namespace Domain.Entities.Users; 

public class Passenger : User {
    public string Lastname { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
}