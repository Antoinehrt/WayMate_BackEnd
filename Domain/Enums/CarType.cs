using System.ComponentModel;

namespace Domain.Enums; 

public enum CarType {
    [Description("MICRO")]
    Micro = 0,
    
    [Description("SEDAN")]
    Sedan = 1,
    
    [Description("HATCHBACK")]
    Hatchback = 2,
    
    [Description("UNIVERSAL")]
    Universal = 3,
    
    [Description("LIFTBACK")]
    Liftback = 4,
    
    [Description("COUPE")]
    Coupe = 5,
    
    [Description("CABRIOLET")]
    Cabriolet = 6,
    
    [Description("ROADSTER")]
    Roadster = 7,
    
    [Description("TARGA")]
    Targa = 8,
    
    [Description("LIMOUSINE")]
    Limousine = 9,
    
    [Description("MUSCLECAR")]
    MuscleCar = 10,
    
    [Description("SPORTCAR")]
    SportCar = 11,
    
    [Description("SUPERCAR")]
    SuperCar = 12,
    
    [Description("SUV")]
    Suv = 13,
    
    [Description("CROSSOVER")]
    Crossover = 14,
    
    [Description("PICKUP")]
    Pickup = 15,
    
    [Description("VAN")]
    Van = 16,
    
    [Description("MINIVAN")]
    Minivan = 17,
    
    [Description("MINIBUS")]
    Minibus = 18,
    
    [Description("BUS")]
    Bus = 19,
    
    [Description("CAMPERVAN")]
    Campervan = 20
}