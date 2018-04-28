namespace Runner.Infrastructure.ServiceBus
{
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using Runner.Application.ServiceBus;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : ISubscriber
    {
        private readonly string brokerList;
        private readonly string topic;

        public Bus(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;
        }

        public void Listen()
        {
            Dictionary<string, object> config = new Dictionary<string, object>
            {
                { "group.id", "runner-consumer" },
                { "enable.auto.commit", "true" },
                { "auto.commit.interval.ms", 5000 },
                { "statistics.interval.ms", 60000 },
                { "bootstrap.servers", brokerList },
                { "default.topic.config", new Dictionary<string, object>()
                    {
                        { "auto.offset.reset", "smallest" }
                    }
                }
            };

            using (var consumer = new Consumer<string, string>(config, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg) =>
                {
                    Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");

                    
                };

                consumer.OnPartitionEOF += (_, end)
                    => Console.WriteLine($"Reached end of topic {end.Topic} partition {end.Partition}, next message will be at offset {end.Offset}");

                consumer.OnError += (_, error)
                    => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                    => Console.WriteLine($"Error consuming from topic/partition/offset {msg.Topic}/{msg.Partition}/{msg.Offset}: {msg.Error}");

                consumer.OnOffsetsCommitted += (_, commit) =>
                {
                    Console.WriteLine($"[{string.Join(", ", commit.Offsets)}]");

                    if (commit.Error)
                    {
                        Console.WriteLine($"Failed to commit offsets: {commit.Error}");
                    }
                    Console.WriteLine($"Successfully committed offsets: [{string.Join(", ", commit.Offsets)}]");
                };

                consumer.OnPartitionsAssigned += (_, partitions) =>
                {
                    Console.WriteLine($"Assigned partitions: [{string.Join(", ", partitions)}], member id: {consumer.MemberId}");
                    consumer.Assign(partitions);
                };

                consumer.OnPartitionsRevoked += (_, partitions) =>
                {
                    Console.WriteLine($"Revoked partitions: [{string.Join(", ", partitions)}]");
                    consumer.Unassign();
                };

                consumer.OnStatistics += (_, json)
                    => Console.WriteLine($"Statistics: {json}");

                consumer.Subscribe(this.topic);

                Console.WriteLine($"Subscribed to: [{string.Join(", ", consumer.Subscription)}]");

                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; 
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");
                while (!cancelled)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
        }
    }
}
