using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Trip;

public interface ITripRepository
{
    IEnumerable<DbTrip> FetchAll();
}