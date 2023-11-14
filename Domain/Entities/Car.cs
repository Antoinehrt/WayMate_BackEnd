using Domain.Enums;

namespace Domain.Entities; 

public class Car {
    private string _numberPlate { get; set; }
    private string _brandType { get; set; }
    private string _model { get; set; }
    private int _nbSeat { get; set; }
    private FuelType _fuelType { get; set; }
    
}