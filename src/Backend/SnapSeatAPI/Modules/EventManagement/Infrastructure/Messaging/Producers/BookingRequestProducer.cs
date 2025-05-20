using EventManagement.Application.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Shared.Application.Interfaces;
using Shared.Domain.Models;

namespace EventManagement.Infrastructure.Messaging
{
    public class BookingRequestProducer : IBookingRequestProducer
    {
        private readonly IKafkaMessagePublisher _KafkaMessagePublisher;
        private readonly IConfiguration _config;
        private readonly string topicName;

        public BookingRequestProducer(IKafkaMessagePublisher KafkaMessagePublisher
            , IConfiguration config)
        {
            _KafkaMessagePublisher = KafkaMessagePublisher;
            _config = config;
            topicName = _config.GetRequiredSection("Kafka")
                .Get<KafkaModel>().TopicName;
        }
        public async Task Produce(BookingRequest message)
        {

            await _KafkaMessagePublisher.PublishAsync(topicName, message);
        }
    }
}
