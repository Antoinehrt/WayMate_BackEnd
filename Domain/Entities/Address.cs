using Domain.Entities.Users;

namespace Domain.Entities; 

public class Address {
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public Passenger Passenger { get; set; }
    
}