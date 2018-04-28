namespace Runner.Infrastructure.ServiceBus
{
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using Runner.Application.ServiceBus;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : ISubscriber
    {
        private readonly string brokerList;
        private readonly string topic;
        private bool cancelled; 

        public Bus(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;
        }

        public IEnumerable<string> Listen()
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

            using (var consumer = new Consumer<string, string>(config, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(this.topic);

                while (!cancelled)
                {
                    Message<string, string> msg;
                    if (consumer.Consume(out msg, -1))
                    {
                        yield return msg.Value;
                    }
                }
            }
        }

        public void Stop()
        {
            cancelled = true;
        }
    }
}
