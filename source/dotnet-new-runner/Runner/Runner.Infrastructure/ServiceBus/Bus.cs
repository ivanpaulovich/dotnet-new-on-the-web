namespace Runner.Infrastructure.ServiceBus
{
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using Runner.Application.Serializers;
    using Runner.Application.ServiceBus;
    using Runner.Domain;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : ISubscriber, IPublisher
    {
        private readonly ISerializer serializer;
        private readonly string brokerList;
        private readonly string topic;
        private bool cancelled;

        private readonly Producer<string, string> producer;

        public Bus(string brokerList, string topic,
            ISerializer serializer)
        {
            this.brokerList = brokerList;
            this.topic = topic;
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

        public IEnumerable<IEntity> Listen()
        {
            Dictionary<string, object> config = new Dictionary<string, object>
            {
                { "group.id", "runner-consumer1" },
                { "bootstrap.servers", brokerList },
                { "default.topic.config", new Dictionary<string, object>()
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };

            cancelled = false;

            using (var consumer = new Consumer<string, string>(
                config,
                new StringDeserializer(Encoding.UTF8),
                new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(this.topic);

                while (!cancelled)
                {
                    Message<string, string> msg;
                    if (consumer.Consume(out msg, -1))
                    {
                        Type entityType = Type.GetType(msg.Key);
                        IEntity entity = (IEntity)serializer.Deserialize(msg.Value, entityType);
                        yield return entity;
                    }
                }
            }
        }

        public void Publish(IEntity entity)
        {
            string data = serializer.Serialize(entity);

            producer.ProduceAsync(
                    topic,
                    entity.GetType().AssemblyQualifiedName, data)
                    .GetAwaiter()
                    .GetResult();
        }

        public void Stop()
        {
            cancelled = true;
        }
    }
}
