using Domain.Enums;

namespace Domain.Entities; 

public class Car {
    public string NumberPlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    private int _nbSeats;
    public FuelType FuelType { get; set; }
    public CarType CarType { get; set; }
    public string Color { get; set; }

    
    public int NbSeats {
        get => _nbSeats;
        set {
            if (value <= 2)
                throw new ArgumentException($"The seat's number of a car have to be greater or equal than 2!");
            if ( CarType != CarType.Limousine || CarType != CarType.Bus || CarType != CarType.Minibus ||
                CarType != CarType.Van || CarType != CarType.Minivan ) {
                if (value > 7) {
                    throw new ArgumentException($"If your car isn't a bus, minibus, van, minivan or a limousine " +
                                                $"the seat's number of a car have to be smaller or equal than 7!");
                }
                
            }
            _nbSeats = value;
        }
    }
    
    public Car(int nbSeats) {
        _nbSeats = nbSeats;
    }
}