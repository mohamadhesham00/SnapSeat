using EventManagement.Infrastructure.Messaging.Consumers;
using KafkaFlow;
using KafkaFlow.Serializer;
using Shared.Domain.Models;
using Shared.Infrastructure.Messaging;

namespace API.Configs
{
    public static class KafkaConfiguration
    {
        public static IServiceCollection ConfigureKafka(this IServiceCollection services,
        IConfiguration configuration)
        {
            var kafkaModel = configuration.GetSection("Kafka").Get<KafkaModel>();
            string producerName = typeof(KafkaMessagePublisher).Name;
            services.AddKafka(
                kafka => kafka
                    .AddCluster(
                        cluster => cluster
                            .WithBrokers(new[] { kafkaModel.Url })
                            .CreateTopicIfNotExists(kafkaModel.TopicName, 1, 1)
                            .AddProducer(
                                producerName,
                                producer => producer
                                    .DefaultTopic(kafkaModel.TopicName)
                                    .AddMiddlewares(m =>
                                        m.AddSerializer<NewtonsoftJsonSerializer>()
                                        )
                            )
                            .AddConsumer(consumer => consumer
                                .Topic(kafkaModel.TopicName)
                                .WithGroupId("Booking-handlers")
                                .WithBufferSize(100)
                                .WithWorkersCount(10)
                                .AddMiddlewares(middleware => middleware
                                    .AddDeserializer<NewtonsoftJsonDeserializer>()
                                    .AddTypedHandlers(h => h.AddHandler<BookingRequestHandler>())
                                )
                            )
                    )
            );
            return services;
        }
    }
}
