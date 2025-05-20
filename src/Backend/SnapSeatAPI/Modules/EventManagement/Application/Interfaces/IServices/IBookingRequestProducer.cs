using Shared.Domain.Models;

namespace EventManagement.Application.Interfaces.IServices
{
    public interface IBookingRequestProducer
    {
        public Task Produce(BookingRequest message);
    }
}
