namespace Shared.Application.Interfaces
{
    public interface IKafkaMessagePublisher
    {
        public Task PublishAsync<T>(string topic, T message);
    }
}
