using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Trip;

public interface ITripRepository
{
    IEnumerable<DbTrip> FetchAll();
    DbTrip Create(int idDriver, bool smoke, float price , bool luggage, bool petFriendly, DateTime date, string driverMessage, bool airCinditioning, int idStartingPoint, int idDestination);
    DbTrip FetchById(int id);
}