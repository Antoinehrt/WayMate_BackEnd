using Domain.Enums;

namespace Domain.Entities; 

public class Car {
    private string _numberPlate { get; set; }
    private string _brand { get; set; }
    private string _model { get; set; }
    private int _nbSeats;
    private FuelType _fuelType { get; set; }
    private CarType _carType { get; set; }

    
    public int NbSeats {
        get => _nbSeats;
        set {
            if (value <= 2)
                throw new ArgumentException($"The seat's number of a car have to be greater or equal than 2!");
            if ( _carType != CarType.Limousine || _carType != CarType.Bus || _carType != CarType.Minibus ||
                _carType != CarType.Van || _carType != CarType.Minivan ) {
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