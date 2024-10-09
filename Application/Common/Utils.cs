using Confluent.Kafka;
using Domain.Entities;
using Newtonsoft.Json;

namespace Application.Common
{
    public static class Utils
    {
        private static readonly ProducerConfig ProducerConfig = new() { BootstrapServers = "localhost:9092" };
        public static void SendTopic(IEnumerable<Product> products)
        {
            using var producer = new ProducerBuilder<Null, string>(ProducerConfig).Build();

            var response = producer.ProduceAsync(
                "Inventory",
                new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(products)
                });
        }
    }
}
