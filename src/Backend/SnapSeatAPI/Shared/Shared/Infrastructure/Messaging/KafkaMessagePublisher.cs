using KafkaFlow.Producers;
using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Messaging
{
    public class KafkaMessagePublisher : IKafkaMessagePublisher
    {
        private readonly IProducerAccessor _producerAccessor;

        public KafkaMessagePublisher(IProducerAccessor producerAccessor)
        {
            _producerAccessor = producerAccessor;
        }

        public async Task PublishAsync<T>(string topic, T message)
        {
            var producer = _producerAccessor.GetProducer(this.GetType().Name);

            await producer.ProduceAsync(
                topic,
                Guid.NewGuid().ToString(),
                message
            );
        }
    }
}
