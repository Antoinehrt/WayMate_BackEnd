using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.UseCases.Address.Dtos;

public class DtoInputUpdateAddress
{
    [JsonIgnore] public int Id { get; set; }
    [Required] public string Street { get; set; }
    [Required] public string PostalCode { get; set; }
    [Required] public string City { get; set; }
    [Required] public string Number { get; set; }
    
    [Required] public string Country { get; set; }
}