namespace Cart.Infrastructure.ServiceBus
{
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using Cart.Application.Serializers;
    using Cart.Application.ServiceBus;
    using Cart.Domain;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : IPublisher
    {
        private readonly ISerializer serializer;
        private readonly string brokerList;
        private readonly string topic;
        private readonly int numberOfPartitions;

        private readonly Producer<string, string> producer;

        private bool cancelled;
        
        public Bus(
            string brokerList,
            string topic,
            int numberOfPartitions,
            ISerializer serializer)
        {
            this.brokerList = brokerList;
            this.topic = topic;
            this.numberOfPartitions = numberOfPartitions;
            this.serializer = serializer;

            producer = new Producer<string, string>(
                new Dictionary<string, object>()
                {{
                    "bootstrap.servers",
                    brokerList
                }},
                new StringSerializer(Encoding.UTF8),
                new StringSerializer(Encoding.UTF8));
        }
        
        public void Publish(IEntity entity)
        {
            string data = serializer.Serialize(entity);
            Random random = new Random();
            int partition = random.Next(numberOfPartitions);

            producer.ProduceAsync(
                    topic,
                    entity.GetType().Name, data, partition);
        }
    }
}
