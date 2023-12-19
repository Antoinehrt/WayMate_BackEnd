using System.ComponentModel;

namespace Domain.Enums; 

public enum FuelType: int  {
    [Description("ELECTRIC")]
    Electric = 0,
    
    [Description("DIESEL")]
    Diesel = 1,
    
    [Description("GASOLINE")]
    Gasoline = 2,
    
    [Description("HYBRID")]
    Hybrid = 3,
    
    [Description("LPG")]
    Lpg = 4,
    
    [Description("OTHER")]
    Other = 5

}