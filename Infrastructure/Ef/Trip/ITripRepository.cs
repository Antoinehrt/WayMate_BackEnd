using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Trip;

public interface ITripRepository
{
    IEnumerable<DbTrip> FetchAll();
    DbTrip Create(int idDriver, bool smoke, float price , bool luggage, bool petFriendly, DateTime date, string driverMessage, bool airCinditioning, int idStartingPoint, int idDestination);
    DbTrip FetchById(int id);
    bool Delete(int id);
    bool Update(int id, int idDriver, bool smoke, double price, bool luggage, bool petFriendly, DateTime date, string driverMessage, bool airConditioning, int idStartingPoint, int idDestination);
}