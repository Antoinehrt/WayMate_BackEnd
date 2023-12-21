using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Address {
    public int IdAddress { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    private User _passenger;
   
}