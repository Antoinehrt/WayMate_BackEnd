using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Address {
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    public string Country { get; set; }
}