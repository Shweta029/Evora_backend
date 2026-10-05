using Evora.Domain.Entity;

namespace Evora.Interface.IServices
{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllBookingsAsync();
    }
}
