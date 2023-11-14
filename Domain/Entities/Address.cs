using Domain.Entities.Users;

namespace Domain.Entities; 

public class Address {
    private string _street { get; set; }
    private string _postalCode { get; set; }
    private string _city { get; set; }
    private string _number { get; set; }
    private Passenger _passenger { get; set; }
    
}