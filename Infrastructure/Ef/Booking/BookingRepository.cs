using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Booking;

public class BookingRepository : IBookingRepository
{
    private readonly WaymateContext _context;

    public BookingRepository(WaymateContext context)
    {
        _context = context;
    }

    public IEnumerable<DbBooking> FetchAll()
    {
        return _context.Booking.ToList();
    }

    public DbBooking FetchById(int id)
    {
        var booking = _context.Booking.FirstOrDefault(b => b.Id == id);
        
        if(booking == null) throw new KeyNotFoundException($"Booking with id{id} has not been found");

        return booking;
    }

    public DbBooking Create(DateTime date, int reservedSeats, int idPassenger, int idTrip)
    {
        var booking = new DbBooking { Date = date, ReservedSeats = reservedSeats, IdPassenger = idPassenger, IdTrip = idTrip };
        _context.Booking.Add(booking);
        _context.SaveChanges();
        return booking;
    }
}