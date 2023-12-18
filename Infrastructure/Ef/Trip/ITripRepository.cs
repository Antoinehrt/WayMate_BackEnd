using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Trip;

public interface ITripRepository
{
    IEnumerable<DbTrip> FetchAll();
    DbTrip Create(int idDriver, bool smoke, float priceKm , bool luggage, bool petFriendly, DateTime date, int occupiedSeats,  int idStartingPoint, int idDestination);
    DbTrip FetchById(int id);
}