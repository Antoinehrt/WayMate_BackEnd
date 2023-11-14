namespace Domain.Entities.Users; 

public class Passenger : User {
    private string _lastname { get; set; }
    private string _firstName { get; set; }
    private string _gender { get; set; }
}