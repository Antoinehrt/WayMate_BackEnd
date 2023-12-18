using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Trip;

public class TripRepository : ITripRepository
{
    private readonly WaymateContext _context;

    public TripRepository(WaymateContext context)
    {
        _context = context;
    }

    public IEnumerable<DbTrip> FetchAll()
    {
        return _context.Trip.ToList();
    }

    public DbTrip Create(int idDriver, bool smoke, float priceKm, bool luggage, bool petFriendly, DateTime date, int occupiedSeats,
        int idStartingPoint, int idDestination)
    {
        var trip = new DbTrip { IdDriver = idDriver, Smoke = smoke, PriceKm = priceKm, Luggage = luggage, PetFriendly = petFriendly, Date = date, OccupiedSeats = occupiedSeats};
        _context.Trip.Add(trip);
        _context.SaveChanges();
        return trip;
    }
}