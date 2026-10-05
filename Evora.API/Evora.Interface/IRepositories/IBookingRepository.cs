using Evora.Domain.Entity;

namespace Evora.Interface.IRepositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
    }
}
