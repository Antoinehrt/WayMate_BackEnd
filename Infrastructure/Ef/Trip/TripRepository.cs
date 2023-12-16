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
}